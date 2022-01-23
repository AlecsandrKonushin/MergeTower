using UnityEngine;

public class CreatorObjects : Singleton<CreatorObjects>
{
    [SerializeField] private GameObject parentTowers;

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
        Transform spawnTransfowm = PositionsOnField.Instance.GetSpawnEnemyTransform;
        Enemy enemy = Instantiate(enemyPrefab, spawnTransfowm);

        return enemy;
    }
}
