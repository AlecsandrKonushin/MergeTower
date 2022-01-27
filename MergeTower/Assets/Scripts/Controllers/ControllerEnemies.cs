using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllerEnemies", menuName = "Controllers/ControllerEnemies")]
public class ControllerEnemies : ControllerBase
{
    [SerializeField] private Enemy[] enemiesPrefab;

    private List<Enemy> enemies = new List<Enemy>();

    public void StartSpawn()
    {

    }

    private void CreateEnemy()
    {

    }


}
