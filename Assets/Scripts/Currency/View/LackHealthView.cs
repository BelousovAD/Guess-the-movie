namespace Currency.View
{
    using UI.View;
    using Reflex.Attributes;
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    public class LackHealthView : MonoBehaviour, IView
    {
        private const float MinAlpha = 0f;
        private const float MaxAlpha = 1f;

        private CanvasGroup _canvasGroup;
        private Currency _health;
        
        [Inject]
        private void Initialize(Health health) =>
            _health = health;

        private void Awake() =>
            _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable()
        {
            _health.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _health.Changed -= UpdateView;

        public void UpdateView()
        {
            if (_health.Value > 0)
            {
                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.interactable = false;
                _canvasGroup.alpha = MinAlpha;
            }
            else
            {
                _canvasGroup.blocksRaycasts = true;
                _canvasGroup.interactable = true;
                _canvasGroup.alpha = MaxAlpha;
            }
        }
    }
}