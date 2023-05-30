public class ButtonNextWeapon : BaseButton
{
    protected override void OnClick()
    {
        WeaponShopManager.Instance.NextWeapon();
    }
}
