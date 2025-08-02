namespace Answer
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(AnswerDataListData), menuName = nameof(Answer) + "/" + nameof(AnswerDataListData))]
    public class AnswerDataListData : ScriptableObject
    {
        [SerializeField] private List<AnswerData> _answerDatas;

        public IEnumerable<AnswerData> AnswerDatas =>
            _answerDatas;
    }
}
