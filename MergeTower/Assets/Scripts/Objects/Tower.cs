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

        public override void OnInitialize()
        {
            rotationSystem = gameObject.AddComponent<RotationSystem>();
            targetSystem = new TargetTowerSystem();

            // TODO: брать дату пули из какого-то хранилища
            BulletData bulletData = new BulletData(TypeBullet.Simple, 2f);
            shootSystem = new ShootSystem(positionShoot.transform.position, bulletData, 1f);

            BoxManager.GetManager<UpdateManager>().AddMoveObject(rotationSystem);

            targetSystem.SubscribeOnGetTarget(StartAttack);
        }

        private void StartAttack(ObjectScene enemy)
        {
            rotationSystem.SetTransformForChange(enemy.transform);
            shootSystem.SetTarget(enemy as Enemy);
        }
    }
}