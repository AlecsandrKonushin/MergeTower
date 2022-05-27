using System;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CoinsManager", menuName = "Managers/CoinsManager")]
    public class CoinsManager : BaseManager
    {
        public event Action<bool> ChangeCanBuyEvent;

        private int countCoins = 30;
        private bool canBuy;

        public void AddCoins(int value)
        {
            countCoins += value;

            ChangeCanBuy();
        }

        public void SubtractCoins(int value)
        {
            countCoins -= value;

            ChangeCanBuy();
        }

        public bool CanBuyTower()
        {
            int price = BoxManager.GetManager<PriceManager>().GetPriceTower();

            if (price <= countCoins)
            {
                return true;
            }
            else
            {
                Debug.Log("End coins!");
                return false;
            }
        }

        public void BuyTower()
        {
            int price = BoxManager.GetManager<PriceManager>().GetPriceTower();

            SubtractCoins(price);
        }

        private void ChangeCanBuy()
        {
            int price = BoxManager.GetManager<PriceManager>().GetPriceTower();

            canBuy = countCoins >= price;

            ChangeCanBuyEvent?.Invoke(canBuy);
        }
    }
}