namespace Loading.View
{
    using BelousovGameDev.UI.View;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class LoadingSliderView : MonoBehaviour, IView
    {
        [SerializeField] private DataLoader _dataLoader;
        
        private Slider _slider;

        private void Awake() =>
            _slider = GetComponent<Slider>();

        private void OnEnable()
        {
            _dataLoader.ProgressUpdated += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _dataLoader.ProgressUpdated -= UpdateView;

        public void UpdateView() =>
            _slider.value = _dataLoader.Progress;
    }
}