namespace UI.View
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public abstract class AbstractTextView : MonoBehaviour, IView
    {
        [SerializeField] private string _format;
        
        protected Text TextField { get; private set; }

        protected string Format => _format;

        protected virtual void Awake() =>
            TextField = GetComponent<Text>();

        public abstract void UpdateView();
    }
}