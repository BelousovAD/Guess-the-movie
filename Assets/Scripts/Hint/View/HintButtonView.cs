namespace Hint.View
{
    using BelousovGameDev.UI.View;
    using Currency;
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AbstractHintButton))]
    public class HintButtonView : MonoBehaviour, IView
    {
        private Button _button;
        private AbstractHintButton _hintButton;
        private Money _money;

        [Inject]
        private void Initialize(Money money) =>
            _money = money;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _hintButton = GetComponent<AbstractHintButton>();
        }

        private void OnEnable()
        {
            _money.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _money.Changed -= UpdateView;

        public void UpdateView() =>
            _button.interactable = _money.Value >= _hintButton.Price;
    }
}