using SystemMove;
using Data;
using Core;

namespace ObjectsOnScene
{
    public class Bullet : ObjectScene
    {
        private BulletData bulletData;
        private MoveObjectSystem moveObjectSystem;
        private ObjectScene target;

        public void SetDataBullet(BulletData bulletData)
        {
            this.bulletData = bulletData;
        }

        public void SetTarget(ObjectScene target)
        {
            this.target = target;
            target.DeathObjectEvent += TargetIsDeath;

            BoxManager.GetManager<EffectManager>().StartBulletEffect(transform);
        }

        public override void OnInitialize()
        {
            moveObjectSystem = gameObject.AddComponent<MoveObjectSystem>();
            moveObjectSystem.SetSpeed = bulletData.GetSpeed;
            moveObjectSystem.SetTransformForChange(target.transform);
        }

        private void TargetIsDeath()
        {
            target.DeathObjectEvent -= TargetIsDeath;
        }
    }
}