namespace Topic.View
{
    using BelousovGameDev.UI.View;
    using Infrastructure;
    using Reflex.Attributes;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TopicTextView : AbstractTMPView
    {
        private ServicesProvider _servicesProvider;
        private Topic _topic;
        
        [Inject]
        private void Initialize(ServicesProvider servicesProvider, Topic topic)
        {
            _servicesProvider = servicesProvider;
            _topic = topic;
        }

        private void OnEnable()
        {
            _topic.ValueChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _topic.ValueChanged -= UpdateView;
        
        public override void UpdateView() =>
            TextField.text = string.Format(Format,
                _servicesProvider.Localisation.GetTranslation(_topic.Current.ToString()));
    }
}