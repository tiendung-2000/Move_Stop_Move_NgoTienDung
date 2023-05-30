public class ButtonHome : BaseButton
{
    protected override void OnClick()
    {
        LevelManager.instance.isGaming = false;
        CameraController.instance.StartCoroutine(CameraController.instance.SwitchTo(CameraState.MainMenu));
        LevelManager.instance.DeleteCharacters();
        LevelManager.instance.RespawnCharacters();
        LevelManager.instance.DisnableALlCharacters();
    }
}
