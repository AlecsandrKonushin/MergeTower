using Core;
using Data;
using ObjectsOnScene;
using UnityEngine;

namespace SystemShoot
{
    public class ShootSystem : IShoot, IWaiting
    {
        private BulletData bulletData;
        private Vector3 positionShoot;

        private Enemy target;

        private bool readyToShoot;
        private float timeReloading;
        private float timeWaitReloading;

        public ShootSystem(Vector3 positionShoot, BulletData bulletData, float timeReloading)
        {
            this.positionShoot = positionShoot;
            this.bulletData = bulletData;
            this.timeReloading = timeReloading;

            timeWaitReloading = timeReloading;

            BoxManager.GetManager<UpdateManager>().AddShootObject(this);
            BoxManager.GetManager<TimeManager>().AddWaitingObject(this);
        }

        public void SetTarget(Enemy enemyTarget)
        {
            target = enemyTarget;

            Shoot();
        }

        public void Shoot()
        {
            if (readyToShoot)
            {
                if (target != null)
                {
                    BoxManager.GetManager<BulletManager>().CreateBullet(bulletData, positionShoot, target);

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
            }
        }
    }
}