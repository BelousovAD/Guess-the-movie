namespace UI.Topic
{
    public class PreviousTopicButton : AbstractTopicButton
    {
        public override void HandleClick() =>
            Topic.MovePrevious();
    }
}