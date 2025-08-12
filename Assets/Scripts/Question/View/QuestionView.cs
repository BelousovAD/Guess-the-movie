namespace Question.View
{
    using BelousovGameDev.UI.View;
    using UnityEngine;

    [RequireComponent(typeof(Question))]
    public class QuestionView : MonoBehaviour, IView
    {
        private const float MinAlpha = 0f;
        private const float MaxAlpha = 1f;

        [SerializeField] private CanvasGroup _questionGroup;
        [SerializeField] private CanvasGroup _noQuestionGroup;
        
        private Question _question;

        private void Awake() =>
            _question = GetComponent<Question>();

        private void OnEnable()
        {
            _question.DataChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _question.DataChanged -= UpdateView;

        public void UpdateView()
        {
            if (_question.HasData)
            {
                _noQuestionGroup.blocksRaycasts = false;
                _noQuestionGroup.interactable = false;
                _noQuestionGroup.alpha = MinAlpha;
                _questionGroup.blocksRaycasts = true;
                _questionGroup.interactable = true;
                _questionGroup.alpha = MaxAlpha;
            }
            else
            {
                _noQuestionGroup.blocksRaycasts = true;
                _noQuestionGroup.interactable = true;
                _noQuestionGroup.alpha = MaxAlpha;
                _questionGroup.blocksRaycasts = false;
                _questionGroup.interactable = false;
                _questionGroup.alpha = MinAlpha;
            }
        }
    }
}