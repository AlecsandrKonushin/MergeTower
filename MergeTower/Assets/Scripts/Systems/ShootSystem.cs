﻿using Core;
using Data;
using ObjectsOnScene;
using UnityEngine;

namespace SystemShoot
{
    public class ShootSystem : IShoot, IWaiting
    {
        private Tower tower;
        private BulletData bulletData;
        private Vector3 positionShoot;

        private bool readyToShoot;
        private float timeReloading;
        private float timeWaitReloading;

        public ShootSystem(Tower tower, Vector3 positionShoot, BulletData bulletData, float timeReloading)
        {
            this.tower = tower;
            this.positionShoot = positionShoot;
            this.bulletData = bulletData;
            this.timeReloading = timeReloading;

            timeWaitReloading = timeReloading;

            BoxManager.GetManager<UpdateManager>().AddShootObject(this);
            BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
        }

        public void Shoot()
        {
            if (readyToShoot)
            {
                if (tower.GetTarget != null)
                {
                    BoxManager.GetManager<BulletManager>().CreateBullet(bulletData, positionShoot, tower.GetTarget);

                    readyToShoot = false;
                    BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
                }
            }
        }

        public void TickTimer()
        {
            timeWaitReloading -= Time.deltaTime;

            if(timeWaitReloading <= 0)
            {
                readyToShoot = true;
                timeWaitReloading = timeReloading;
                BoxManager.GetManager<TimeManager>().RemoveWaitingObject(this);

                Shoot();
            }
        }
    }
}