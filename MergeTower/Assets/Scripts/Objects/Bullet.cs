using UnityEngine;
using SystemMove;
using Data;

namespace ObjectsOnScene
{
    public class Bullet : ObjectScene
    {
        private BulletData bulletData;
        private MoveObjectSystem moveObjectSystem;

        private void SetDataBullet(BulletData bulletData)
        {
            this.bulletData = bulletData;
        }
    }
}