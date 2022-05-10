using Core;
using UI;
using Towers;

public class ButtonBuyTower : MyButton
{
    private TypeTower typeTower = TypeTower.Pirat;

    protected override void OtherActionClick()
    {
        BoxManager.GetManager<GameManager>().ClickBuyTowerButton(typeTower);
    }
}
