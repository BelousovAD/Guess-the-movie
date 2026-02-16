namespace Question
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(QuestionDataListData), menuName = nameof(Question) + "/" + nameof(QuestionDataListData))]
    public class QuestionDataListData : ScriptableObject
    {
        [SerializeField] private List<QuestionData> _questionDatas;

        public IEnumerable<QuestionData> QuestionDatas =>
            _questionDatas;
    }
}
