using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllerEnemies", menuName = "Controllers/ControllerEnemies")]
public class ControllerEnemies : ControllerBase, IWaiting
{
    [SerializeField] private Enemy[] enemiesPrefab;

    private List<Enemy> enemies = new List<Enemy>();

    public void StartSpawn()
    {
        TimeCome();
    }

    public void TimeCome()
    {
        CreateEnemy();
        TimeController.Instance.AddWaiting(this, 2f);
    }

    private void CreateEnemy()
    {
        CreatorObjects.Instance.CreateEnemy(enemiesPrefab[0]);
    }
}
