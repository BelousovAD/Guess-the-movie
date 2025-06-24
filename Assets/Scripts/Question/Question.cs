namespace Question
{
    using Answer;
    using Extensions;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class Question : MonoBehaviour
    {
        [SerializeField] private AnswerList _answerList;
        [SerializeField] private List<Answer> _answers;

        private QuestionData _data;
        private readonly List<AnswerData> _answerDatas = new();

        public event Action DataChanged;

        public Sprite Sprite =>
            _data.Sprite;

        public void Initialize(QuestionData data)
        {
            _data = data;
            GenerateAnswers();

            for (int i = 0; i < _answers.Count; i++)
            {
                _answers[i].Initialize(_answerDatas[i]);
            }

            DataChanged?.Invoke();
        }

        private void GenerateAnswers()
        {
            _answerDatas.Clear();
            _answerDatas.AddRange(GetRandomAnswersFromList(_answers.Count));

            if (_answerDatas.Contains(_data.RightAnswer) == false)
            {
                _answerDatas[0] = _data.RightAnswer;
            }

            _answerDatas.Shuffle();
        }

        private IEnumerable<AnswerData> GetRandomAnswersFromList(int count)
        {
            List<AnswerData> choosedAnswerDatas = new(count);
            List<AnswerData> temporaryList = new(_answerList.Datas);
            AnswerData temporaryData;

            for (int i = 0; i < count; i++)
            {
                temporaryData = temporaryList[UnityEngine.Random.Range(0, temporaryList.Count)];
                choosedAnswerDatas.Add(temporaryData);
                temporaryList.Remove(temporaryData);
            }

            return choosedAnswerDatas;
        }
    }
}
