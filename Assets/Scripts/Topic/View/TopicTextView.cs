namespace Topic.View
{
    using BelousovGameDev.UI.View;
    using Reflex.Attributes;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TopicTextView : AbstractTMPView
    {
        private Topic _topic;
        
        [Inject]
        private void Initialize(Topic topic) =>
            _topic = topic;

        private void OnEnable()
        {
            _topic.ValueChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _topic.ValueChanged -= UpdateView;
        
        public override void UpdateView() =>
            TextField.text = string.Format(Format, _topic.Current);
    }
}