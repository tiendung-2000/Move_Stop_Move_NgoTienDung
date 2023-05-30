public class ButtonCloseSkinShop : BaseButton
{
    protected override void OnClick()
    {
        CameraController.instance.StartCoroutine(CameraController.instance.SwitchTo(CameraState.MainMenu));
        SkinShopManager.instance.CloseSkinShop();
    }
}
