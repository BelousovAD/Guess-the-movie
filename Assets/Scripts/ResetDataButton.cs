using BelousovGameDev.UI.Button;
using romanlee17.MirraGames;

public class ResetDataButton : AbstractButton
{
    public override void HandleClick() =>
        MirraSDK.Prefs.DeleteAll();
}