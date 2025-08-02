namespace Answer.View
{
    using BelousovGameDev.UI.View;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AnswerTextView : AbstractTMPView
    {
        [SerializeField] private Answer _answer;

        private void OnEnable()
        {
            _answer.DataChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _answer.DataChanged -= UpdateView;

        public override void UpdateView()
        {
            // TODO: Localize
            TextField.text = string.Format(Format, _answer.LocalizationKey);
        }
    }
}
