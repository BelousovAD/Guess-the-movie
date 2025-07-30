namespace Topic.View
{
    using BelousovGameDev.UI.View;
    using Reflex.Attributes;
    using UnityEngine;

    public abstract class AbstractTopicView : MonoBehaviour, IView
    {
        [Inject]
        private void Initialize(Topic topic) =>
            Topic = topic;
        
        protected Topic Topic { get; private set; }

        protected virtual void OnEnable()
        {
            Topic.ValueChanged += UpdateView;
            UpdateView();
        }

        protected virtual void OnDisable() =>
            Topic.ValueChanged -= UpdateView;

        public abstract void UpdateView();
    }
}