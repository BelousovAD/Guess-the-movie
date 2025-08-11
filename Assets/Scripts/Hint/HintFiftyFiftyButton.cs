namespace Hint
{
    public class HintFiftyFiftyButton : AbstractHintButton
    {
        public override void HandleClick()
        {
            if (Money.TrySpend(Price))
            {
                Question.HideHalfAnswers();
            }
        }
    }
}