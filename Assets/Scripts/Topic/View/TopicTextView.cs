namespace Topic.View
{
    using TMPro;
    using UI.Topic.View;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TopicTextView : AbstractTopicView
    {
        [SerializeField] private string _format = "{0}";
        
        private TextMeshProUGUI _textField;

        private void Awake() =>
            _textField = GetComponent<TextMeshProUGUI>();
        
        public override void UpdateView() =>
            _textField.text = string.Format(_format, Topic.Current);
    }
}