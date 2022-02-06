using UnityEngine;

public class ShootSystem : MonoBehaviour, IShoot
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
    }

    public void Shoot()
    {
        if (StatesGame.Instance.CanShoot)
        {
            if (target != null)
            {

            }
        }
    }
}
