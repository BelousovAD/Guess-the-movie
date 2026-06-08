namespace UI.Localization
{
    using Button;
    using Infrastructure;
    using Reflex.Attributes;
    using Savvy.Services.Localization;
    using UnityEngine;

    public class SwitchLanguageButton : AbstractButton
    {
        [SerializeField] private LocalizationSettings _localizationSettings;

        private int _index = -1;
        private ServicesProvider _servicesProvider;

        [Inject]
        private void Infrastructure(ServicesProvider servicesProvider) =>
            _servicesProvider = servicesProvider;
        
        public override void HandleClick()
        {
            _index = (_index + 1) % _localizationSettings.TranslationsData.Length;
            _servicesProvider.Localisation.SetLanguage(_localizationSettings.TranslationsData[_index].SystemLanguage);
        }
    }
}