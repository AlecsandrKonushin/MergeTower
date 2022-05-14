using ObjectsOnScene;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EnemiesManager", menuName = "Managers/EnemiesManager")]
    public class EnemiesManager : BaseManager, IWaiting
    {
        public Action<Enemy> NewEnemy;

        [SerializeField] private Enemy[] enemiesPrefab;

        private List<Enemy> enemies = new List<Enemy>();

        private float timeSpawn = 1.5f;
        private float timeWaitSpawn = 0;

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
                float zPos = SceneObjects.Instance.GetGoldHeap.transform.position.z;
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

        public override void OnInitialize()
        {
            Timer.Instance.AddWaitingObject(this);
        }

        public override void OnStart()
        {
            CreateEnemy();
        }

        public void TickTimer()
        {
            timeWaitSpawn -= Time.deltaTime;

            if (timeWaitSpawn <= 0)
            {
                Timer.Instance.RemoveWaitingObject(this);

                if (BoxManager.GetManager<GameManager>().CanSpawn)
                {
                    CreateEnemy();
                }
                else
                {
                    GameManager.ChangeCanSpawn += WaitCanSpawn;
                }
            }
        }

        private void WaitCanSpawn(bool canSpawn)
        {
            if (canSpawn)
            {
                GameManager.ChangeCanSpawn -= WaitCanSpawn;
                CreateEnemy();
            }
        }

        private void CreateEnemy()
        {
            Enemy enemy = BoxManager.GetManager<CreatorManager>().CreateEnemy(enemiesPrefab[0]);
            enemies.Add(enemy);
            NewEnemy?.Invoke(enemy);

            timeWaitSpawn = timeSpawn;
            Timer.Instance.AddWaitingObject(this);
            Debug.Log("new time in enemies controller");
        }
    }
}