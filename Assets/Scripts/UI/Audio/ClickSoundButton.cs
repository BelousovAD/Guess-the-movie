namespace UI.Audio
{
    using BelousovGameDev.UI.Button;
    using global::Audio;

    public class ClickSoundButton : AbstractButton
    {
        public override void HandleClick() =>
            ClickSoundSource.Instance.Play();
    }
}