namespace Question
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using Reflex.Attributes;
    using UnityEngine;

    public class QuestionSwitcher : MonoBehaviour
    {
        [SerializeField] private Question _question;
        
        private List<QuestionData> _questionDatas;
        private int _index;

        [Inject]
        private void Initialize(QuestionDataList questionDataList)
        {
            _questionDatas = new List<QuestionData>(questionDataList.QuestionDatas);
            _questionDatas.Shuffle();
            SetCurrentQuestion();
        }

        private void OnEnable() =>
            _question.Completed += MoveNext;

        private void OnDisable() =>
            _question.Completed -= MoveNext;

        private void MoveNext()
        {
            _index = ++_index % _questionDatas.Count;
            SetCurrentQuestion();
        }

        private void SetCurrentQuestion() =>
            _question.Initialize(_questionDatas[_index]);
    }
}