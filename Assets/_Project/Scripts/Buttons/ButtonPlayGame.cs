public class ButtonPlayGame : BaseButton
{
    protected override void OnClick()
    {
        CameraController.instance.StartCoroutine(CameraController.instance.SwitchTo(CameraState.Gaming));
        LevelManager.instance.PlayGame();
    }
}
