using UnityEngine;

public class CreatorObjects : Singleton<CreatorObjects>
{
    [SerializeField] private GameObject parentTowers;
    [SerializeField] private GameObject parentEnemies;

    public Tower CreateTower(Tower towerPrefab, Tile tileForSpawn)
    {
        Vector3 positionSpawn = tileForSpawn.transform.position;
        Quaternion rotationSpawn = Quaternion.Euler(0, 0, 0);
        positionSpawn.y += 1f;

        Tower tower = Instantiate(towerPrefab, positionSpawn, rotationSpawn);
        tower.transform.SetParent(parentTowers.transform);
        tower.InitObject();

        return tower;
    }

    public Enemy CreateEnemy(Enemy enemyPrefab)
    {
        GameObject objectSpawn = PositionsScene.Instance.GetSpawnEnemyPos;
        Enemy enemy = Instantiate(enemyPrefab, objectSpawn.transform.position, objectSpawn.transform.rotation);
        enemy.transform.SetParent(parentEnemies.transform);
        enemy.InitObject();

        return enemy;
    }
}
