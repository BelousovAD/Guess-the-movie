namespace Question
{
    using System;
    using System.Collections.Generic;
    using Answer;
    using Extensions;
    using Reflex.Attributes;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class Question : MonoBehaviour
    {
        [SerializeField] private List<Answer> _answers;

        private QuestionData _data;
        private List<AnswerData> _allAnswerDatas;
        private readonly List<AnswerData> _currentAnswerDatas = new();

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
            }

            DataChanged?.Invoke();
        }
        
        [Inject]
        private void Initialize(AnswerDataList answerDataList) =>
            _allAnswerDatas = new List<AnswerData>(answerDataList.AnswerDatas);

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
                Completed?.Invoke();
            }
        }
    }
}
