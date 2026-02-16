namespace Currency.View
{
    using Extensions;
    using Reflex.Attributes;

    public class CupTMPView : AbstractCurrencyTMPView
    {
        [Inject]
        private void Initialize(Cup cup) =>
            base.Initialize(cup);
        
        public override void UpdateView() =>
            TextField.text = string.Format(Format, LargeNumberFormatter.Format(Currency.Value));
    }
}