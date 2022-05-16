using SystemShoot;
using SystemMove;
using Core;
using SystemTarget;
using Data;
using UnityEngine;

namespace ObjectsOnScene
{
    public class Tower : ObjectScene
    {
        [SerializeField] private GameObject positionShoot;

        private TargetTowerSystem targetSystem;
        private ShootSystem shootSystem;
        private RotationSystem rotationSystem;

        private Enemy target;

        public Enemy GetTarget { get => target; }

        public override void OnInitialize()
        {
            rotationSystem = gameObject.AddComponent<RotationSystem>();
            targetSystem = new TargetTowerSystem();

            // TODO: брать дату пули из какого-то хранилища
            BulletData bulletData = new BulletData(TypeBullet.Simple, 2f);
            shootSystem = new ShootSystem(this, positionShoot.transform.position, bulletData, 1f);

            targetSystem.SubscribeOnGetTarget(StartAttack);
        }

        private void StartAttack(ObjectScene enemy)
        {
            target = enemy as Enemy;
            target.DeathObjectEvent += ChooseNewTarget;
            rotationSystem.SetTransformForChange(enemy.transform);
        }

        private void ChooseNewTarget()
        {
            target = null;
            targetSystem.SubscribeOnGetTarget(StartAttack);
        }
    }
}