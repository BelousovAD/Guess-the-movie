namespace UI.Topic
{
    public class PreviousTopicButton : AbstractTopicButton
    {
        public override void OnClick() =>
            Topic.MovePrevious();
    }
}