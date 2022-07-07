using SystemMove;
using Data;
using Core;
using UnityEngine;

// лишний пробел
namespace ObjectsOnScene
{
    public class Bullet : ObjectScene
    {
        private BulletData bulletData;
        private MoveObjectSystem moveSystem;
        private ObjectScene target;
        // лишний пробел

        public void SetDataBullet(BulletData bulletData) // Этот метод сделать свойством set
        {
            this.bulletData = bulletData;
        }

        public void SetTarget(ObjectScene target)
        {  
            this.target = target;            
            target.DeathObjectEvent += TargetIsDeath;            
            BoxManager.GetManager<EffectManager>().StartBulletEffect(transform);
        }

        public override void OnInitialize() // Этот метод должен быть в самом верху. Сначала инициализация.
        {
            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            moveSystem.SetSpeed = bulletData.GetSpeed;
            moveSystem.SetTransformForChange(target.transform.GetComponent<Enemy>()._hitposition.transform);            
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