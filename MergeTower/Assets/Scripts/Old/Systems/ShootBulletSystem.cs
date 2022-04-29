using UnityEngine;

namespace ShootSystem
{
    public class ShootBulletSystem : MonoBehaviour, IShoot
    {
        private Bullet bulletPrefab;
        private float speedShoot;

        private Enemy target;

        public void Init(Bullet bulletPrefab, float speedShoot)
        {
            this.bulletPrefab = bulletPrefab;
            this.speedShoot = speedShoot;
        }

        public void SetTarget(Enemy enemyTarget)
        {
            target = enemyTarget;

            Shoot();
        }

        public void Shoot()
        {
            if (target != null)
            {
                Debug.Log($"shoot on {target.gameObject.name}");
            }
        }
    }
}