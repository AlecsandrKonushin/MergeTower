using UnityEngine;

public class CreatorObjects : Singleton<CreatorObjects>
{
    [SerializeField] private GameObject parentTowers;
    [SerializeField] private GameObject spawnEnemyPosition; // TODO: должна передаваться в метод, не ссылкой
    [SerializeField] private GameObject targetEnemyPosition; // TODO: должна передаваться в метод, не ссылкой

    public Tower CreateTower(Tower towerPrefab, Tile tileForSpawn)
    {
        Vector3 positionSpawn = tileForSpawn.transform.position;
        positionSpawn.y += 1f;

        Tower tower = Instantiate(towerPrefab, positionSpawn, tileForSpawn.transform.rotation);
        tower.transform.SetParent(parentTowers.transform);

        return tower;
    }

    public Enemy CreateEnemy(Enemy enemyPrefab)
    {
        Enemy enemy = Instantiate(enemyPrefab, spawnEnemyPosition.transform);

        return enemy;
    }
}
