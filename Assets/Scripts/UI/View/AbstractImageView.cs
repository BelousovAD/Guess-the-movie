namespace UI.View
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Image))]
    public abstract class AbstractImageView : MonoBehaviour, IView
    {
        [SerializeField] private Sprite _defaultSprite;
        
        protected Image Image { get; private set; }

        protected Sprite DefaultSprite => _defaultSprite;

        protected virtual void Awake() =>
            Image = GetComponent<Image>();

        public abstract void UpdateView();
    }
}
