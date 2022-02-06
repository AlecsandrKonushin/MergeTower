using UnityEngine;

public class Tower : ObjectScene
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float speedShoot;

    private TargetSystem targetSystem;
    private ShootSystem shootSystem;

    public override void InitObject()
    {
        targetSystem = gameObject.AddComponent<TargetSystem>();
        shootSystem = gameObject.AddComponent<ShootSystem>();
        shootSystem.Init(bulletPrefab, speedShoot);
    }


}
