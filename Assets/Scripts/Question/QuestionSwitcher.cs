namespace Question
{
    using System.Collections.Generic;
    using Extensions;
    using Reflex.Attributes;
    using UnityEngine;

    public class QuestionSwitcher : MonoBehaviour
    {
        private const int Index = 0;
        
        [SerializeField] private Question _question;
        
        private List<QuestionData> _questionDatas;

        [Inject]
        private void Initialize(QuestionDataList questionDataList)
        {
            _questionDatas = new List<QuestionData>(questionDataList.QuestionDatas);
            _questionDatas.Shuffle();
            _questionDatas.Add(null);
            SetCurrentQuestion();
        }

        private void OnEnable()
        {
            _question.Completed += MoveNext;

            if (_question.IsCompleted)
            {
                MoveNext();
            }
        }

        private void OnDisable() =>
            _question.Completed -= MoveNext;

        private void MoveNext()
        {
            _questionDatas.RemoveAt(Index);
            SetCurrentQuestion();
        }

        private void SetCurrentQuestion() =>
            _question.Initialize(_questionDatas[Index]);
    }
}