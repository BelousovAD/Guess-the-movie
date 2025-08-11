namespace Question
{
    using System;
    using System.Collections.Generic;
    using Answer;
    using Currency;
    using Extensions;
    using Reflex.Attributes;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class Question : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _moneyToEarnAmount = 1;
        [SerializeField, Min(0)] private int _healthToSpendAmount = 1;
        [SerializeField] private List<Answer> _answers;

        private readonly List<AnswerData> _currentAnswerDatas = new();
        private QuestionData _data;
        private List<AnswerData> _allAnswerDatas;
        private Currency _money;
        private Currency _health;

        public event Action DataChanged;
        public event Action Completed;

        public Sprite Sprite =>
            _data.Icon;

        public void Initialize(QuestionData data)
        {
            _data = data;
            GenerateAnswers();

            for (int i = 0; i < _answers.Count; i++)
            {
                _answers[i].Initialize(_currentAnswerDatas[i]);
                _answers[i].Show();
            }

            DataChanged?.Invoke();
        }
        
        [Inject]
        private void Initialize(AnswerDataList answerDataList, Money money, Health health)
        {
            _allAnswerDatas = new List<AnswerData>(answerDataList.AnswerDatas);
            _money = money;
            _health = health;
        }

        private void OnEnable()
        {
            foreach (Answer answer in _answers)
            {
                answer.Chosen += CheckAnswer;
            }
        }

        private void OnDisable()
        {
            foreach (Answer answer in _answers)
            {
                answer.Chosen -= CheckAnswer;
            }
        }

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
                Completed?.Invoke();
            }
            else
            {
                _health.TrySpend(_healthToSpendAmount);
            }
        }
    }
}
