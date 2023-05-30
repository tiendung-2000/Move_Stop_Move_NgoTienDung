public class ButtonPreviousWeapon : BaseButton
{
    protected override void OnClick()
    {
        WeaponShopManager.Instance.PreviousWeapon();
    }
}
