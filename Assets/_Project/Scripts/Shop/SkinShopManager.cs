using UnityEngine;

public enum ItemType
{
    Hat = 0, Pants = 1, Shield = 2, FullSet = 3
}
public class SkinShopManager : MonoBehaviour
{
    public PlayerWearSkinItems player;
    public GameObject[] hats;
    public Material[] pants;
    public GameObject[] shields;
    public GameObject[] fullSet;
    public ItemController[] itemControllers;
    public GameObject[] buyButtons;

    public static SkinShopManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void BuyItem(ItemController itemController)
    {
        Item item = itemController.buttons[itemController.currentIndex].GetComponent<Item>();
        if (item.isPurchased == false && LevelManager.instance.coin >= item.cost)
        {
            item.isPurchased = true;
            LevelManager.instance.coin -= item.cost;
            UIManager.instance.UpdateCoin();
            itemController.buyButtonText.text = Constant.USING;
            itemController.usingIndex = itemController.currentIndex;
            UnlockSkin(item);
        }
        else if (item.isPurchased == true)
        {
            if (itemController.usingIndex != itemController.currentIndex)
            {
                itemController.buyButtonText.text = Constant.USING;
                itemController.usingIndex = itemController.currentIndex;
            }
            else
            {
                itemController.buyButtonText.text = Constant.USE;
                itemController.usingIndex = -1;
            }
        }
    }

    public void CloseSkinShop()
    {
        PutItemsOnPlayer();
    }

    public void PutItemsOnPlayer()
    {
        ItemController hatController = itemControllers[(int)ItemType.Hat];
        if (hatController.usingIndex >= 0)
        {
            player.WearHat(hatController.usingIndex);
        }
        else
        {
            player.DestroyCurrentHat();
        }
        ItemController pantsController = itemControllers[(int)ItemType.Pants];
        if (pantsController.usingIndex >= 0)
        {
            player.WearPants(pantsController.usingIndex);
        }
        else
        {
            player.DestroyCurrentPants();
        }
        ItemController shieldController = itemControllers[(int)ItemType.Shield];
        if (shieldController.usingIndex >= 0)
        {
            player.WearShield(shieldController.usingIndex);
        }
        else
        {
            player.DestroyCurrentShield();
        }
    }

    public void CloseAllBuyButtons()
    {
        for(int i = 0; i < buyButtons.Length; i++)
        {
            buyButtons[i].SetActive(false);
        }
    }

    public void UnlockSkin(Item skin)
    {
        skin.lockObj.SetActive(false);
    }
}
