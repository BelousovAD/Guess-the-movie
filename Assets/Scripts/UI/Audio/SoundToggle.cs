namespace UI.Audio
{
    using global::Audio;
    using Reflex.Attributes;

    public class SoundToggle : AudioToggle
    {
        [Inject]
        private void Initialize(Sound sound) =>
            base.Initialize(sound);
    }
}