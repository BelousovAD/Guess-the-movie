namespace Answer.UI.View
{
    using BelousovGameDev.UI.View;
    using Currency;
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class AnswerButtonView : MonoBehaviour, IView
    {
        private Currency _health;
        private Button _answerButton;
        
        [Inject]
        private void Initialize(Health health) =>
            _health = health;

        private void Awake() =>
            _answerButton = GetComponent<Button>();

        private void OnEnable()
        {
            _health.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _health.Changed -= UpdateView;

        public void UpdateView() =>
            _answerButton.interactable = _health.Value > 0;
    }
}