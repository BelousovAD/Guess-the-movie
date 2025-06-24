namespace Answer
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(AnswerData), menuName = nameof(Answer) + "/" + nameof(AnswerData))]
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
