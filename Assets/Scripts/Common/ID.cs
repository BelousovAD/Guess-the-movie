namespace Common
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(ID), menuName = nameof(Common) + "/" + nameof(ID))]
    public class ID : ScriptableObject
    {
        [SerializeField] private string _value = string.Empty;

        public string Value =>
            _value;

#if UNITY_EDITOR
        private void OnValidate() =>
            _value = name;
#endif
    }
}
