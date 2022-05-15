namespace Data
{
    public class BulletData
    {
        private TypeBullet typeBullet;
        private float speed;

        public TypeBullet GetTypeBullet { get => typeBullet; }
        public float GetSpeed { get => speed; }

        public BulletData(TypeBullet typeBullet, float speed)
        {
            this.typeBullet = typeBullet;
            this.speed = speed;
        }
    }

    public enum TypeBullet
    {
        Simple
    }
}