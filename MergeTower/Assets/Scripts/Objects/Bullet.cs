using SystemMove;
using Data;
using Core;
using UnityEngine;
using System;

namespace ObjectsOnScene
{
    public class Bullet : ObjectScene
    {
        private BulletData bulletData;
        private MoveObjectSystem moveSystem;
        private ObjectScene target;
        public BulletData DataBullet{ set => bulletData = value; }

        public override void OnInitialize()
        {
            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            moveSystem.SetSpeed = bulletData.GetSpeed;
            moveSystem.SetTransformForChange(target.transform.GetComponent<Enemy>().hitPosition.transform);
        }

        public void SetDataBullet(BulletData bulletData) // Этот метод сделать свойством set
        {
            this.bulletData = bulletData;  
        }   

        public void SetTarget(ObjectScene target)
        {  
            this.target = target;            
            target.DeathObjectEvent += TargetIsDeath;
            EffectManager manager = BoxManager.GetManager<EffectManager>();
            EffectManager.TypeEffect typeEffect = EffectManager.TypeEffect.StartBulletEffect;
            manager.SetEffect(typeEffect, transform);
        }

        private void TargetIsDeath(ObjectScene objectScene)
        {
            objectScene.DeathObjectEvent -= TargetIsDeath;
            
            Death();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ObjectScene>(out ObjectScene objectScene))
            {
                if (objectScene == target)
                {
                    objectScene.Damage(bulletData.GetDamange);
                    Destroy(gameObject);
                    Death();
                }
                else
                {
                    Debug.Log("Не моя цель");
                }
            }
        }

        protected override void Death()
        {
            moveSystem.StopMove();
            DeathInvoke();
        }
    }
}