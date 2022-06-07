﻿using Data;
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

        [SerializeField] private SCRO_Enemy[] enemiesData;

        private List<Enemy> enemies = new List<Enemy>();
        private List<Enemy> poolEnemies = new List<Enemy>();

        private bool canSpawn;
        private float timeSpawn = 3f;
        private float timeWaitSpawn = 0;

        #region INITIALIZE 

        public override void OnInitialize()
        {
            GameManager.ChangeCanSpawn += (bool canSpawn) => { this.canSpawn = canSpawn; };
        }

        public override void OnStart()
        {
            CreateEnemy();
        }

        #endregion INITIALIZE

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
            }

            return enemy;
        }


        public void TickTimer()
        {
            timeWaitSpawn -= Time.deltaTime;

            if (timeWaitSpawn <= 0)
            {
                BoxManager.GetManager<TimeManager>().RemoveWaitingObject(this);

                if (canSpawn)
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
            SCRO_Enemy scroEnemy = enemiesData[0];
            Enemy enemy = BoxManager.GetManager<CreatorManager>().CreateEnemy(scroEnemy.Prefab);

            EnemyData enemyData = new EnemyData(scroEnemy.Health, scroEnemy.Speed, scroEnemy.PriceReward);
            enemy.SetData = enemyData;

            enemy.OnInitialize();

            enemies.Add(enemy);
            enemy.DeathObjectEvent += EnemyDeath;
            NewEnemy?.Invoke(enemy);

            timeWaitSpawn = timeSpawn;
            BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
        }

        private void EnemyDeath(ObjectScene objectScene)
        {
            objectScene.DeathObjectEvent -= EnemyDeath;

            if (objectScene is Enemy)
            {
                Enemy enemy = objectScene as Enemy;
                enemies.Remove(enemy);
                poolEnemies.Add(enemy);
                enemy.gameObject.SetActive(false);

                BoxManager.GetManager<CoinsManager>().AddCoins(enemy.GetPriceReward);
            }
            else
            {
                Debug.Log($"<color=red>Объект не Enemy! {objectScene.gameObject.name}</color>");
            }
        }
    }
}