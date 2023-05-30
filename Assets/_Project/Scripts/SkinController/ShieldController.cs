public class ShieldController : ItemController
{
    public override void OnButtonClick(int index)
    {
        player.WearShield(index);
        Item item = buttons[index].GetComponent<Item>();
        if (item.isPurchased == false)
        {
            buyButtonText.text = item.cost.ToString();
        }
        else
        {
            if (usingIndex == index)
            {
                buyButtonText.text = Constant.USING;
            }
            else
            {
                buyButtonText.text = Constant.USE;
            }
        }
        currentIndex = index;
    }
}
