using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ControllerEnemies", menuName = "Controllers/ControllerEnemies")]
    public class EnemiesManager : BaseManager, IWaiting
    {
        public delegate void NewEnemy(Enemy enemy);
        public event NewEnemy EventNewEnemy;

        [SerializeField] private Enemy[] enemiesPrefab;

        private List<Enemy> enemies = new List<Enemy>();

        /// <summary>
        /// Получить ближайшего к базе Enemy
        /// </summary>
        /// <returns></returns>
        public Enemy GetFirstEnemy()
        {
            Enemy enemy = null;

            if (enemies.Count > 0)
            {
                enemy = enemies[0];
                float zPos = PositionsScene.Instance.GetTargetEnemyPos.transform.position.z;
                float distance = zPos - enemy.transform.position.z;

                if (enemies.Count > 1)
                {
                    for (int i = 1; i < enemies.Count; i++)
                    {
                        float newDistance = zPos - enemies[i].transform.position.z;

                        if (newDistance < distance)
                        {
                            enemy = enemies[i];
                        }
                    }
                }
            }

            return enemy;
        }

        private int count = 0;

        public void StartSpawn()
        {
            TimeCome();
        }

        public void TimeCome()
        {
            count++;
            if (count > 1)
                CreateEnemy();

            Timer.Instance.AddWaiting(this, 2f);
        }

        private void CreateEnemy()
        {
            Enemy enemy = BoxManager.GetManager<CreatorManager>().CreateEnemy(enemiesPrefab[0]);
            enemies.Add(enemy);

            EventNewEnemy?.Invoke(enemy);
        }
    }
}