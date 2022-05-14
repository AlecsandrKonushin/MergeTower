using Core;
using ObjectsOnScene;
using UnityEngine;

namespace SystemShoot
{
    public class ShootSystem : IShoot, IWaiting
    {
        private Bullet bulletPrefab;
        private float speedShoot;

        private Enemy target;

        private bool readyToShoot;
        private float timeReloading;
        private float timeWaitReloading;

        public ShootSystem(Bullet bulletPrefab, float speedShoot, float timeReloading)
        {
            this.bulletPrefab = bulletPrefab;
            this.speedShoot = speedShoot;
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
                    Debug.Log($"Выстрел в {target}");

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