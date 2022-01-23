using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllerEnemies", menuName = "Controllers/ControllerEnemies")]
public class ControllerEnemies : ControllerBase
{
    [SerializeField] private Enemy[] enemiesPrefab;

    private List<Enemy> enemies = new List<Enemy>();

    public void CreateEnemy()
    {
        Enemy newEnemy = CreatorObjects.Instance.CreateEnemy(enemiesPrefab[0]);
        Vector3 targetPosition = PositionsOnField.Instance.GetTargetEnemyPos;
        newEnemy.InitEnemy(TypeMove.Simple, targetPosition);

        enemies.Add(newEnemy);
    }
}
