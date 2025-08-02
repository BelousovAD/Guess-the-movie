namespace Loading.View
{
    using BelousovGameDev.UI.View;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class LoadingTextView : AbstractTextView
    {
        private const int LoopCount = -1;
        private const float Duration = 3f;
        
        [SerializeField] private string _localizationKey;
        
        private Tweener _textAnimation;

        private void OnEnable()
        {
            TextField.text = string.Empty;
            _textAnimation = TextField
                .DOText(_localizationKey, Duration)
                .SetEase(Ease.OutExpo)
                .SetLoops(LoopCount);
        }

        private void OnDisable() =>
            _textAnimation.Kill();

        public override void UpdateView()
        { }
    }
}