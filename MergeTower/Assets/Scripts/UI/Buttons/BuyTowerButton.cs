using Core;
using UI;
using Towers;

public class BuyTowerButton : MyButton
{
    private TypeTower typeTower = TypeTower.Pirat;

    protected override void OtherActionClick()
    {
        BoxManager.GetManager<GameManager>().ClickBuyTowerButton(typeTower);
    }
}
