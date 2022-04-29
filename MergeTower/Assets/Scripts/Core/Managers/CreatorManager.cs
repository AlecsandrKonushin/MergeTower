using UnityEngine;

namespace Core
{
    public class CreatorManager : BaseManager
    {
        public Tower CreateTower(Tower towerPrefab, Tile tileForSpawn)
        {
            Vector3 positionSpawn = tileForSpawn.transform.position;
            Quaternion rotationSpawn = Quaternion.Euler(0, 0, 0);
            positionSpawn.y += 1f;

            Tower tower = Instantiate(towerPrefab, positionSpawn, rotationSpawn);

            // TODO: получить transform parent
            //tower.transform.SetParent(parentTowers.transform);
            tower.InitObject();

            return tower;
        }

        public Enemy CreateEnemy(Enemy enemyPrefab)
        {
            GameObject objectSpawn = PositionsScene.Instance.GetSpawnEnemyPos;
            Enemy enemy = Instantiate(enemyPrefab, objectSpawn.transform.position, objectSpawn.transform.rotation);

            // TODO: получить transform parent            
            //enemy.transform.SetParent(parentEnemies.transform);
            enemy.InitObject();

            return enemy;
        }
    }
}