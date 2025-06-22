namespace Answer
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(AnswerData), menuName = nameof(Question) + "/" + nameof(AnswerData))]
    public class AnswerData : ScriptableObject
    {
        [SerializeField] private string _localizationKey;

        public string LocalizationKey =>
            _localizationKey;

#if UNITY_EDITOR
        private void OnValidate() =>
            _localizationKey = name;
#endif
    }
}
