namespace Loading.View
{
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class LoadingTextView : MonoBehaviour
    {
        private const int LoopCount = -1;
        private const float Duration = 3f;
        
        [SerializeField] private string _localizeKey;
        
        private Text _textField;
        private Tweener _textAnimation;

        private void Awake() =>
            _textField = GetComponent<Text>();

        private void OnEnable()
        {
            _textField.text = string.Empty;
            _textAnimation = _textField
                .DOText(_localizeKey, Duration)
                .SetEase(Ease.OutExpo)
                .SetLoops(LoopCount);
        }

        private void OnDisable() =>
            _textAnimation.Kill();
    }
}