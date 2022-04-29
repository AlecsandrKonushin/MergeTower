using UnityEngine;
using ShootSystem;
using MoveSystem;
using Core;

public class Tower : ObjectScene
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float speedShoot;

    private TargetSystem targetSystem;
    private ShootBulletSystem shootSystem;
    private RotationObjectSystem rotationSystem;

    public override void InitObject()
    {
        targetSystem = gameObject.AddComponent<TargetSystem>();
        rotationSystem = gameObject.AddComponent<RotationObjectSystem>();
        shootSystem = gameObject.AddComponent<ShootBulletSystem>();

        //UpdateGame.Instance.AddMoveObject(rotationSystem);
        shootSystem.Init(bulletPrefab, speedShoot);

        targetSystem.SubscribeOnGetTargetEnemy(StartAttack);
    }

    private void StartAttack(Enemy enemy)
    {
        rotationSystem.SetPositionForChange(enemy.transform);
        shootSystem.SetTarget(enemy);
    }
}
