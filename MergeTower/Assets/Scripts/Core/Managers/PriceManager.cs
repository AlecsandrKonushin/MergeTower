using System;
using System.Collections.Generic;
using Towers;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "PriceManager", menuName = "Managers/PriceManager")]
    public class PriceManager : BaseManager
    {
        public event Action<int> ChangePriceEvent;

        private List<DataPriceTower> dataPriceTowers;

        private int currentPrice = 10;
        private int stepUpPrice = 2;

        public override void OnInitialize()
        {
            dataPriceTowers = new List<DataPriceTower>();

            // TODO: ????????? ???? price towers
            dataPriceTowers.Add(new DataPriceTower(TypeTower.Pirat, 20));
        }

        public int GetPriceTower()
        {
            return currentPrice;        
        }

        public void UpPriceAfterBuyTower()
        {
            currentPrice *= stepUpPrice;

            ChangePriceEvent?.Invoke(currentPrice);
        }
    }
}