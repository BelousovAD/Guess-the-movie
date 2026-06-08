namespace Currency.View
{
    using UI.View;

    public abstract class AbstractCurrencyTMPView : AbstractTMPView
    {
        protected Currency Currency { get; private set; }
        
        protected void Initialize(Currency currency) =>
            Currency = currency;

        private void OnEnable()
        {
            Currency.Changed += UpdateView;
            Currency.MaxValueChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable()
        {
            Currency.Changed -= UpdateView;
            Currency.MaxValueChanged -= UpdateView;
        }
    }
}