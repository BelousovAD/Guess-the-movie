namespace Question
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Image))]
    public class QuestionImageView : MonoBehaviour
    {
        [SerializeField] private Question _question;
        
        private Image _image;

        private void Awake() =>
            _image = GetComponent<Image>();

        private void OnEnable() =>
            _question.DataChanged += UpdateView;

        private void OnDisable() =>
            _question.DataChanged -= UpdateView;

        private void UpdateView() =>
            _image.sprite = _question.Sprite;
    }
}
