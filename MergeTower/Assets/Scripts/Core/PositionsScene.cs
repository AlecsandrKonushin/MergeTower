using UnityEngine;

public class PositionsScene : Singleton<PositionsScene>
{
    [SerializeField] private GameObject spawnEnemyPos;
    [SerializeField] private GameObject targetEnemyPos;

    public GameObject GetSpawnEnemyPos { get => spawnEnemyPos; }
    public GameObject GetTargetEnemyPos { get => targetEnemyPos; }
}
