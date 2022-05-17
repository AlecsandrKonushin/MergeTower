namespace Data
{
    public class BulletData
    {
        private TypeBullet typeBullet;
        private float speed;
        private int damage;

        public TypeBullet GetTypeBullet { get => typeBullet; }
        public float GetSpeed { get => speed; }
        public int GetDamange { get => damage; }

        public BulletData(TypeBullet typeBullet, float speed, int damage)
        {
            this.typeBullet = typeBullet;
            this.speed = speed;
            this.damage = damage;
        }
    }

    public enum TypeBullet
    {
        Simple
    }
}