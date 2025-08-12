namespace Question.View
{
    using BelousovGameDev.UI.View;
    using UnityEngine;

    public class QuestionIconView : AbstractImageView
    {
        [SerializeField] private Question _question;

        private void OnEnable()
        {
            _question.DataChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _question.DataChanged -= UpdateView;

        public override void UpdateView() =>
            Image.sprite = _question.Sprite ?? DefaultSprite;
    }
}