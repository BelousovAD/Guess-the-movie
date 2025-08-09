namespace Currency.View
{
    using Extensions;
    using Reflex.Attributes;

    public class MoneyTMPView : AbstractCurrencyTMPView
    {
        [Inject]
        private void Initialize(Money money) =>
            base.Initialize(money);
        
        public override void UpdateView() =>
            TextField.text = string.Format(Format, LargeNumberFormatter.Format(Currency.Value));
    }
}
