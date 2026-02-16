namespace Question
{
    using System;
    using System.Collections.Generic;
    using Answer;
    using Currency;
    using Extensions;
    using Reflex.Attributes;
    using romanlee17.MirraGames;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class Question : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _moneyToEarnAmount = 1;
        [SerializeField, Min(0)] private int _healthToSpendAmount = 1;
        [SerializeField, Min(0)] private int _cupToEarnAmount = 1;
        [SerializeField] private List<Answer> _answers;

        private readonly List<AnswerData> _currentAnswerDatas = new();
        private QuestionData _data;
        private List<AnswerData> _allAnswerDatas;
        private Currency _money;
        private Currency _health;
        private Currency _cup;

        public event Action DataChanged;
        public event Action Completed;

        public Sprite Sprite => _data?.Icon;

        public bool HasData => _data is not null;

        public bool IsCompleted { get; private set; }

        public void Initialize(QuestionData data)
        {
            _data = data;

            if (_data is null)
            {
                DataChanged?.Invoke();
                return;
            }
            
            Load();

            if (IsCompleted)
            {
                Completed?.Invoke();
                return;
            }
            
            GenerateAnswers();

            for (int i = 0; i < _answers.Count; i++)
            {
                _answers[i].Initialize(_currentAnswerDatas[i]);
                _answers[i].Show();
            }

            DataChanged?.Invoke();
        }
        
        [Inject]
        private void Initialize(AnswerDataList answerDataList, Money money, Health health, Cup cup)
        {
            _allAnswerDatas = new List<AnswerData>(answerDataList.AnswerDatas);
            _money = money;
            _health = health;
            _cup = cup;
        }

        private void OnEnable() =>
            _answers.ForEach(answer => answer.Chosen += CheckAnswer);

        private void OnDisable() =>
            _answers.ForEach(answer => answer.Chosen -= CheckAnswer);

        public void HideHalfAnswers()
        {
            List<Answer> answersToHide = new(_answers);
            answersToHide.RemoveAll(answer => answer.Id == _data.RightAnswer.Id);
            answersToHide.RemoveAt(Random.Range(0, answersToHide.Count));
            answersToHide.ForEach(answer => answer.Hide());
        }

        public void HideWrongAnswers()
        {
            List<Answer> answersToHide = new(_answers);
            answersToHide.RemoveAll(answer => answer.Id == _data.RightAnswer.Id);
            answersToHide.ForEach(answer => answer.Hide());
        }

        private void GenerateAnswers()
        {
            _currentAnswerDatas.Clear();
            _currentAnswerDatas.AddRange(GetRandomAnswersFromList(_answers.Count));

            if (_currentAnswerDatas.Contains(_data.RightAnswer) == false)
            {
                _currentAnswerDatas[0] = _data.RightAnswer;
            }

            _currentAnswerDatas.Shuffle();
        }

        private IEnumerable<AnswerData> GetRandomAnswersFromList(int count)
        {
            List<AnswerData> chosenAnswerDatas = new(count);
            List<AnswerData> temporaryList = new(_allAnswerDatas);
            AnswerData temporaryData;

            for (int i = 0; i < count; i++)
            {
                temporaryData = temporaryList[Random.Range(0, temporaryList.Count)];
                chosenAnswerDatas.Add(temporaryData);
                temporaryList.Remove(temporaryData);
            }

            return chosenAnswerDatas;
        }

        private void CheckAnswer(Answer answer)
        {
            if (answer.Id == _data.RightAnswer.Id)
            {
                _money.Earn(_moneyToEarnAmount);
                _cup.Earn(_cupToEarnAmount);
                IsCompleted = true;
                Save();
                Completed?.Invoke();
            }
            else
            {
                _health.TrySpend(_healthToSpendAmount);
            }
        }

        private void Save()
        {
            MirraSDK.Prefs.SetBool(_data.RightAnswer.Id, IsCompleted);
            MirraSDK.Prefs.Save();
        }

        private void Load() =>
            IsCompleted = MirraSDK.Prefs.GetBool(_data.RightAnswer.Id);
    }
}
