namespace Timer.View
{
    using Reflex.Attributes;

    public class HealthRestorerTimerTMPView : TimerTMPView
    {
        [Inject]
        private void Initialize(HealthRestorer healthRestorer) =>
            Initialize(healthRestorer.Timer);
    }
}