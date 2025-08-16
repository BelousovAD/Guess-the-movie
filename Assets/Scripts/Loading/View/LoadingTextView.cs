namespace Loading.View
{
    using BelousovGameDev.UI.View;
    using DG.Tweening;
    using Infrastructure;
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class LoadingTextView : AbstractTextView
    {
        private const int LoopCount = -1;
        private const float Duration = 3f;
        
        [SerializeField] private string _localizationKey;

        private ServicesProvider _servicesProvider;
        private Tweener _textAnimation;

        [Inject]
        private void Initialize(ServicesProvider servicesProvider) =>
            _servicesProvider = servicesProvider;

        private void OnEnable()
        {
            TextField.text = string.Empty;
            _textAnimation = TextField
                .DOText(_servicesProvider.Localisation.GetTranslation(_localizationKey), Duration)
                .SetEase(Ease.OutExpo)
                .SetLoops(LoopCount);
        }

        private void OnDisable() =>
            _textAnimation.Kill();

        public override void UpdateView()
        { }
    }
}