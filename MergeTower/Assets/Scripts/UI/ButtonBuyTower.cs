using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuyTower : ButtonMy
{
    protected override void OtherButtonAction()
    {
        ActionsGame.Instance.BuyTower();
    }
}
