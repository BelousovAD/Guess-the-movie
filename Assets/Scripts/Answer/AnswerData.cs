namespace Answer
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(AnswerData), menuName = nameof(Answer) + "/" + nameof(AnswerData))]
    public class AnswerData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _localizationKey;

        public string Id => _id;
        
        public string LocalizationKey => _localizationKey;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _id = name;
            _localizationKey = name;
        }
#endif
    }
}
