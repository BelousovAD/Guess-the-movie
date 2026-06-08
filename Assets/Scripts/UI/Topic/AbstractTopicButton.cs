namespace UI.Topic
{
    using Button;
    using global::Topic;
    using Reflex.Attributes;

    public abstract class AbstractTopicButton : AbstractButton
    {
        [Inject]
        private void Initialize(Topic topic) =>
            Topic = topic;
        
        protected Topic Topic { get; private set; }
    }
}