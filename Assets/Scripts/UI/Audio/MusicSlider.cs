namespace UI.Audio
{
    using global::Audio;
    using Reflex.Attributes;

    public class MusicSlider : AudioSlider
    {
        [Inject]
        private void Initialize(Music music) =>
            base.Initialize(music);
    }
}