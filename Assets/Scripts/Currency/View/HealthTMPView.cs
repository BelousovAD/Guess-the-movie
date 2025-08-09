namespace Currency.View
{
    using Extensions;
    using Reflex.Attributes;

    public class HealthTMPView : AbstractCurrencyTMPView
    {
        [Inject]
        private void Initialize(Health health) =>
            base.Initialize(health);
        
        public override void UpdateView() =>
            TextField.text = string.Format(Format,
                LargeNumberFormatter.Format(Currency.Value),
                LargeNumberFormatter.Format(Currency.MaxValue));
    }
}