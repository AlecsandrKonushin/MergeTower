using ObjectsOnScene;
using System.Collections.Generic;
using Towers;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "TowersManager", menuName = "Managers/TowersManager")]
    public class TowersManager : BaseManager
    {
        [SerializeField] private Tower[] towerPrefabs;

        private List<Tower> towers = new List<Tower>();

        public void BuyTower(TypeTower typeTower)
        {
            Tile tile = AllObjectsInScene.Instance.GetTilesParent.GetTileForSpawnTower();

            Tower newTower = BoxManager.GetManager<CreatorManager>().CreateTower(towerPrefabs[0], tile);

            towers.Add(newTower);
        }
    }
}