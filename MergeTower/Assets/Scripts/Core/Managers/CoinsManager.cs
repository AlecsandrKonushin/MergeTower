using Towers;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CoinsManager", menuName = "Managers/CoinsManager")]
    public class CoinsManager : BaseManager
    {
        private int countCoins = 100;

        public bool CanBuyTower(TypeTower typeTower)
        {
            int price = BoxManager.GetManager<PriceManager>().GetPriceTower(typeTower);

            if (price <= countCoins)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BuyTower(TypeTower typeTower)
        {
            int price = BoxManager.GetManager<PriceManager>().GetPriceTower(typeTower);

            countCoins -= price;
        }
    }
}