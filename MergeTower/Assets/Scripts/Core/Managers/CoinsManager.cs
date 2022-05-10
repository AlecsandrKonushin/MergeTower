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
            return true;
        }
    }
}