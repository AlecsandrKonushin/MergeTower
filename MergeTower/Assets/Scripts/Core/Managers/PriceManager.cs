using System.Collections.Generic;
using Towers;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "PriceManager", menuName = "Managers/PriceManager")]
    public class PriceManager : BaseManager
    {
        private List<DataPriceTower> dataPriceTowers;

        public override void OnInitialize()
        {
            dataPriceTowers = new List<DataPriceTower>();

            // TODO: получение даты price towers
            dataPriceTowers.Add(new DataPriceTower(TypeTower.Pirat, 20));
        }

        public int GetPriceTower(TypeTower typeTower)
        {
            foreach (var data in dataPriceTowers)
            {
                if(data.GetTypeTower == typeTower)
                {
                    return data.GetPriceTower;
                }
            }

            Debug.Log($"<color=red>Ќе найдена цена дл€ башни типа {typeTower}!</color>");

            return 10;        
        }
    }
}