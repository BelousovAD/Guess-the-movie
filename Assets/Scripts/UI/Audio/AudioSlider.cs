namespace UI.Audio
{
    using BelousovGameDev.UI.Slider;
    using global::Audio;

    public class AudioSlider : AbstractSlider
    {
        private Audio _audio;

        protected void Initialize(Audio audioObject) =>
            _audio = audioObject;
        
        protected override void HandleValue(float value) =>
            _audio.SetVolume(value);
    }
}