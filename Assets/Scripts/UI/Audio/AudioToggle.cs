namespace UI.Audio
{
    using BelousovGameDev.UI.Toggle;
    using global::Audio;

    public class AudioToggle : AbstractToggle
    {
        private Audio _audio;

        protected void Initialize(Audio audioObject) =>
            _audio = audioObject;
        
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