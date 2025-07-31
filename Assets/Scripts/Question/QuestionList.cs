namespace Question
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(QuestionList), menuName = nameof(Question) + "/" + nameof(QuestionList))]
    public class QuestionList : ScriptableObject
    {
        [SerializeField] private List<QuestionData> _Datas;

        public IEnumerable<QuestionData> Datas =>
            _Datas;
    }
}
