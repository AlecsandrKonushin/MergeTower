using ObjectsOnScene;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CreatorManager", menuName = "Managers/CreatorManager")]
    public class CreatorManager : BaseManager
    {
        private GameObject towersParent;
        private GameObject enemiesParent;

        public override void OnInitialize()
        {
            towersParent = new GameObject(NamesData.TowersParentName);
            enemiesParent = new GameObject(NamesData.EnemiesParentName);
        }

        public Tower CreateTower(Tower towerPrefab, Tile tileForSpawn)
        {
            Vector3 positionSpawn = tileForSpawn.transform.position;
            Quaternion rotationSpawn = Quaternion.Euler(0, 0, 0);
            positionSpawn.y += 1f;

            Tower tower = Instantiate(towerPrefab, positionSpawn, rotationSpawn);

            tower.transform.SetParent(towersParent.transform);
            tower.OnInitialize();

            return tower;
        }

        public Enemy CreateEnemy(Enemy enemyPrefab)
        {
            GameObject objectSpawn = SceneObjects.Instance.GetSpawnEnemyPosition.gameObject;
            Enemy enemy = Instantiate(enemyPrefab, objectSpawn.transform.position, objectSpawn.transform.rotation);
           
            enemy.transform.SetParent(enemiesParent.transform);
            enemy.OnInitialize();

            return enemy;
        }
    }
}