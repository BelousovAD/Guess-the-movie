namespace UI.Audio
{
    using Toggle;
    using global::Audio;

    public class AudioToggle : AbstractToggle
    {
        private Audio _audio;

        protected void Initialize(Audio audioObject) =>
            _audio = audioObject;

        protected override void Awake()
        {
            base.Awake();
            Toggle.isOn = _audio.IsEnabled;
        }

        protected override void HandleValue(bool value)
        {
            if (value)
            {
                _audio.Enable();
            }
            else
            {
                _audio.Disable();
            }
        }
    }
}