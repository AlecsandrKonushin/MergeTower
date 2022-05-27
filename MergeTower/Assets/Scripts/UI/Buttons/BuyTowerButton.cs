using Core;
using UI;
using Towers;
using UnityEngine.UI;
using UnityEngine;

public class BuyTowerButton : MyButton
{
    private TypeTower typeTower = TypeTower.Pirat;

    private Text priceTowerText;

    public override void OnStart()
    {
        priceTowerText = GetComponentInChildren<Text>();
        priceTowerText.text = BoxManager.GetManager<PriceManager>().GetPriceTower().ToString();

        BoxManager.GetManager<PriceManager>().ChangePriceEvent += NewPriceTower;
        BoxManager.GetManager<CoinsManager>().ChangeCanBuyEvent += ChangeStateButton;
    }

    protected override void OtherActionClick()
    {
        BoxManager.GetManager<GameManager>().ClickBuyTowerButton(typeTower);        
    }

    private void NewPriceTower(int price)
    {
        priceTowerText.text = price.ToString();        
    }

    private void ChangeStateButton(bool canBuy)
    {
        if (canBuy)
        {
            UnLockButton();
        }
        else
        {
            LockButton();
        }
    }

    private void LockButton()
    {
        GetComponent<Button>().interactable = false;
    }

    private void UnLockButton()
    {
        GetComponent<Button>().interactable = true;
    }
}
