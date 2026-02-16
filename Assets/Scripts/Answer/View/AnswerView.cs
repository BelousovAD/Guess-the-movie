namespace Answer.View
{
    using BelousovGameDev.UI.View;
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Answer))]
    public class AnswerView : MonoBehaviour, IView
    {
        private const float MinAlpha = 0f;
        private const float MaxAlpha = 1f;
        
        private CanvasGroup _canvasGroup;
        private Answer _answer;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _answer = GetComponent<Answer>();
        }

        private void OnEnable()
        {
            _answer.VisibilityChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _answer.VisibilityChanged -= UpdateView;

        public void UpdateView()
        {
            if (_answer.IsVisible)
            {
                _canvasGroup.interactable = true;
                _canvasGroup.alpha = MaxAlpha;
                _canvasGroup.blocksRaycasts = true;
            }
            else
            {
                _canvasGroup.interactable = false;
                _canvasGroup.alpha = MinAlpha;
                _canvasGroup.blocksRaycasts = false;
            }
        }
    }
}