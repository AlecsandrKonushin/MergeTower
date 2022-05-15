using SystemMove;
using Data;

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
        }
    }
}