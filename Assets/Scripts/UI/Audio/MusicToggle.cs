namespace UI.Audio
{
    using global::Audio;
    using Reflex.Attributes;

    public class MusicToggle : AudioToggle
    {
        [Inject]
        private void Initialize(Music music) =>
            base.Initialize(music);
    }
}