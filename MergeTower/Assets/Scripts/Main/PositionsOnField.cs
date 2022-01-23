using UnityEngine;

public class PositionsOnField : Singleton<PositionsOnField>
{
    [SerializeField] private GameObject spawnEnemyPosition;
    [SerializeField] private GameObject targetEnemyPosition;

    public Transform GetSpawnEnemyTransform { get => spawnEnemyPosition.transform; }
    public Vector3 GetTargetEnemyPos { get => targetEnemyPosition.transform.position; }
}
