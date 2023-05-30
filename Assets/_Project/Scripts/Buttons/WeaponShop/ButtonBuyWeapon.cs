public class ButtonBuyWeapon : BaseButton
{
    protected override void OnClick()
    {
        WeaponShopManager.Instance.BuyWeapon();
    }
}
