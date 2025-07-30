namespace UI.Topic.View
{
    using global::Topic;
    using global::Topic.View;
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    public class ChooseTopicButtonView : AbstractTopicView
    {
        [SerializeField] private TopicType _exceptedTopic;

        private CanvasGroup _canvasGroup;

        private void Awake() =>
            _canvasGroup = GetComponent<CanvasGroup>();

        public override void UpdateView() =>
            _canvasGroup.interactable = Topic.Current != _exceptedTopic;
    }
}
