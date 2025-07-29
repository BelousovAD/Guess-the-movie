namespace UI.Topic
{
    public class NextTopicButton : AbstractTopicButton
    {
        public override void OnClick() =>
            Topic.MoveNext();
    }
}