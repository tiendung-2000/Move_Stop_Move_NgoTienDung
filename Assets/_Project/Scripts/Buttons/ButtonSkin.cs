public class ButtonSkin : BaseButton
{
    protected override void OnClick()
    {
        CameraController.instance.StartCoroutine(CameraController.instance.SwitchTo(CameraState.Skin));
    }
}
