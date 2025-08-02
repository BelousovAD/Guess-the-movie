namespace Loading.View
{
    using BelousovGameDev.UI.View;
    using UnityEngine;

    public class LoadingImageView : AbstractImageView
    {
        [SerializeField] private DataLoader _dataLoader;
        
        private void OnEnable()
        {
            _dataLoader.ProgressUpdated += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _dataLoader.ProgressUpdated -= UpdateView;
        
        public override void UpdateView() =>
            Image.fillAmount = _dataLoader.Progress;
    }
}