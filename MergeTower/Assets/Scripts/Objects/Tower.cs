using SystemShoot;
using SystemMove;
using Core;
using SystemTarget;
using Data;
using UnityEngine;
using SystemEffect;

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
            BoxManager.GetManager<EffectManager>().SetEffect(TypeEffect.SpawnEffect, transform);
            rotationSystem = gameObject.AddComponent<RotationSystem>();
            targetSystem = new TargetTowerSystem();

            // TODO: брать дату пули из какого-то хранилища
            BulletData bulletData = new BulletData(TypeBullet.Simple, 20f, 1);
            shootSystem = new ShootSystem(this, positionShoot.transform, bulletData, 0.5f);
            targetSystem.SubscribeOnGetTarget(StartAttack); 
        }

        private void StartAttack(ObjectScene enemy)
        {            
            target = enemy as Enemy;
            target.DeathObjectEvent += ChooseNewTarget;
            rotationSystem.SetTransformForChange(enemy.transform);            
        }

        private void ChooseNewTarget(ObjectScene objectScene)
        {
            target = null;
            targetSystem.SubscribeOnGetTarget(StartAttack);           
        }
    }
}