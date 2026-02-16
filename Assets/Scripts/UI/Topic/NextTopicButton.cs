namespace UI.Topic
{
    public class NextTopicButton : AbstractTopicButton
    {
        public override void HandleClick() =>
            Topic.MoveNext();
    }
}