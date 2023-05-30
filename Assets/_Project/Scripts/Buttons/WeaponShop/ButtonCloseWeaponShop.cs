using UnityEngine;
public class ButtonCloseWeaponShop : BaseButton
{
    [SerializeField] private Player player;

    protected override void OnClick()
    {
        player.GetWeaponFromInventory();
    }
}
