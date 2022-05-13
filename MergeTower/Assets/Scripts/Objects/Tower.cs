using UnityEngine;
using SystemShoot;
using SystemMove;
using Core;
using SystemTarget;

namespace ObjectsOnScene
{
    public class Tower : ObjectScene
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float speedShoot;

        private TargetTowerSystem targetSystem;
        private ShootSystem shootSystem;
        private RotationSystem rotationSystem;

        public override void OnInitialize()
        {
            rotationSystem = gameObject.AddComponent<RotationSystem>();
            targetSystem = new TargetTowerSystem();
            shootSystem = new ShootSystem(bulletPrefab, speedShoot, 1f);

            UpdateGame.Instance.AddMoveObject(rotationSystem);

            targetSystem.SubscribeOnGetTarget(StartAttack);
        }

        private void StartAttack(ObjectScene enemy)
        {
            rotationSystem.SetTransformForChange(enemy.transform);
            shootSystem.SetTarget(enemy as Enemy);
        }
    }
}