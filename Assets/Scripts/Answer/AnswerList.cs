namespace Answer
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(AnswerList), menuName = nameof(Answer) + "/" + nameof(AnswerList))]
    public class AnswerList : ScriptableObject
    {
        [SerializeField] private List<AnswerData> _Datas;

        public IEnumerable<AnswerData> Datas =>
            _Datas;
    }
}
