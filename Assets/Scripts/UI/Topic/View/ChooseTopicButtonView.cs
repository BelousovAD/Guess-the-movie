namespace UI.Topic.View
{
    using BelousovGameDev.UI.View;
    using global::Topic;
    using global::Topic.View;
    using Reflex.Attributes;
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    public class ChooseTopicButtonView : MonoBehaviour, IView
    {
        [SerializeField] private TopicType _exceptedTopic;

        private CanvasGroup _canvasGroup;
        private Topic _topic;
        
        [Inject]
        private void Initialize(Topic topic) =>
            _topic = topic;
        
        private void Awake() =>
            _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable()
        {
            _topic.ValueChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _topic.ValueChanged -= UpdateView;

        public void UpdateView() =>
            _canvasGroup.interactable = _topic.Current != _exceptedTopic;
    }
}
