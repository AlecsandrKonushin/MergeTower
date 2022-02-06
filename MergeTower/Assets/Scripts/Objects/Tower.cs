using UnityEngine;

public class Tower : ObjectScene
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float speedShoot;

    private TargetSystem targetSystem;
    private ShootSystem shootSystem;
    private RotationSystem rotationSystem;

    public override void InitObject()
    {
        targetSystem = gameObject.AddComponent<TargetSystem>();
        rotationSystem = gameObject.AddComponent<RotationSystem>();
        shootSystem = gameObject.AddComponent<ShootSystem>();

        UpdateController.Instance.AddMoveObject(rotationSystem);
        shootSystem.Init(bulletPrefab, speedShoot);

        targetSystem.SubscribeOnGetTargetEnemy(StartAttack);
    }

    private void StartAttack(Enemy enemy)
    {
        rotationSystem.SetPositionForChange(enemy.transform);
        shootSystem.SetTarget(enemy);
    }
}
