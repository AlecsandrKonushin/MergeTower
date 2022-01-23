using System.Collections.Generic;
using UnityEngine;

public class ActionsGame : Singleton<ActionsGame>
{
    private List<IListenerBuyTower> listenersBuyTower = new List<IListenerBuyTower>();

    public void AddListenerBuyTower(IListenerBuyTower listener)
    {
        listenersBuyTower.Add(listener);
    }

    public void BuyTower()
    {
        if(listenersBuyTower.Count > 0)
        {
            foreach (var listener in listenersBuyTower)
            {
                listener.BuyTower();
            }
        }
        else
        {
            Debug.Log("listenersBuyTower = 0");
        }
    }
}
