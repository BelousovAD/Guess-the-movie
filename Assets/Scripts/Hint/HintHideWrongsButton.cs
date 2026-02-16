namespace Hint
{
    public class HintHideWrongsButton : AbstractHintButton
    {
        public override void HandleClick()
        {
            if (Money.TrySpend(Price))
            {
                Question.HideWrongAnswers();
            }
        }
    }
}