namespace Answer.View
{
    using BelousovGameDev.UI.View;
    using Infrastructure;
    using Reflex.Attributes;
    using UnityEngine;

    public class AnswerTextView : AbstractTMPView
    {
        [SerializeField] private Answer _answer;

        private ServicesProvider _servicesProvider;

        [Inject]
        private void Initialize(ServicesProvider servicesProvider) =>
            _servicesProvider = servicesProvider;

        private void OnEnable()
        {
            _answer.DataChanged += UpdateView;
            _servicesProvider.Localisation.OnLocalizationUpdate += UpdateView;
            UpdateView();
        }

        private void OnDisable()
        {
            _answer.DataChanged -= UpdateView;
            _servicesProvider.Localisation.OnLocalizationUpdate -= UpdateView;
        }

        public override void UpdateView() =>
            TextField.text = string.Format(Format,
                _servicesProvider.Localisation.GetTranslation(_answer.LocalizationKey));
    }
}
