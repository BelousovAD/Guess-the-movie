namespace Timer.View
{
    using System;
    using UI.View;

    public class TimerTMPView : AbstractTMPView
    {
        private Timer _timer;

        protected void Initialize(Timer timer) =>
            _timer = timer;

        private void OnEnable()
        {
            _timer.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _timer.Changed -= UpdateView;

        public override void UpdateView() =>
            TextField.text = TimeSpan.FromSeconds(_timer.GetTimeRemaining()).ToString(Format);
    }
}