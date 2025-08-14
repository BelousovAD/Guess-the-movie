namespace Localization
{
    using BelousovGameDev.UI.Button;

    public class SwitchLanguageButton : AbstractButton
    {
        public override void HandleClick() =>
            LocalizationManager.Instance.SwitchCurrentLocalizationData();
    }
}