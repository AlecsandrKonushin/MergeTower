using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "TowersManager", menuName = "Managers/TowersManager")]
    public class TowersManager : BaseManager
    {
        [SerializeField] private Tower[] towerPrefabs;

        private List<Tower> towers = new List<Tower>();

        public void BuyTower()
        {
            //Tile tile = TilesParent.Instance.GetTileForSpawnTower();

            //if (tile == null)
            //{
            //    return;
            //}
            //else
            //{
            //    Tower newTower = CreatorObjects.Instance.CreateTower(towerPrefabs[0], tile);

            //    towers.Add(newTower);
            //}
        }

    }
}