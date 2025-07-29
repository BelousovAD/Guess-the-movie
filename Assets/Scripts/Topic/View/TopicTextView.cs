namespace Topic.View
{
    using BelousovGameDev.UI.View;
    using Reflex.Attributes;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TopicTextView : MonoBehaviour, IView
    {
        [SerializeField] private string _format = "{0}";
        
        private TextMeshProUGUI _textField;
        private Topic _topic;

        [Inject]
        private void Initialize(Topic topic) =>
            _topic = topic;

        private void Awake() =>
            _textField = GetComponent<TextMeshProUGUI>();

        private void OnEnable()
        {
            _topic.ValueChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _topic.ValueChanged -= UpdateView;
        
        public void UpdateView() =>
            _textField.text = string.Format(_format, _topic.Current);
    }
}