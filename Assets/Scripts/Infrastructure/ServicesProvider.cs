namespace Infrastructure
{
    using Savvy.Infrastructure;
    using Savvy.Services.Localization;
    using Savvy.Services.Mediation;
    using Savvy.Services.WebGL;

    public class ServicesProvider : NetSavvy
    {
        private ILocalizationService _localization;
        private IMediationService _mediation;
        private IWebGLService _web;
        
        public ILocalizationService Localisation =>
            _localization ??= GetService<ILocalizationService>();

        public IMediationService Mediation =>
            _mediation ??= GetService<IMediationService>();

        public IWebGLService Web =>
            _web ??= GetService<IWebGLService>();
    }
}