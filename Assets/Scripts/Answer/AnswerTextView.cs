namespace Answer
{
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AnswerTextView : MonoBehaviour
    {
        [SerializeField] private Answer _answer;
        
        private TextMeshProUGUI _textField;

        private void Awake() =>
            _textField = GetComponent<TextMeshProUGUI>();

        private void OnEnable() =>
            _answer.DataChanged += UpdateView;

        private void OnDisable() =>
            _answer.DataChanged -= UpdateView;

        private void UpdateView()
        {
            // TODO: Localize
            _textField.text = _answer.LocalizationKey;
        }
    }
}
