using SystemMove;
using Data;
using Core;
using UnityEngine;
using SystemEffect;

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
            moveSystem.SetTransformForChange(target.transform.GetComponent<Enemy>().HitPosition.transform);
        }

        public BulletData SetDataBullet{ set => bulletData = value; }

        public void SetTarget(ObjectScene target)
        {
            this.target = target;
            target.DeathObjectEvent += TargetIsDeath;

            BoxManager.GetManager<EffectManager>().ShowEffect(TypeEffect.StartBulletEffect, transform);
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