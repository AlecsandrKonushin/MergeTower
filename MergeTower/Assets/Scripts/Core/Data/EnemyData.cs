using System;

namespace Data
{
    public class EnemyData
    {
        public event Action EndHealth;

        private int health;
        private float speed;

        public int GetHealth { get => health; }
        public float GetSpeed { get => speed; }

        public EnemyData(int health, float speed)
        {
            this.health = health;
            this.speed = speed;
        }

        public void DownHealth(int value)
        {
            health -= value;

            if (health <= 0)
            {
                EndHealth?.Invoke();
            }
        }
    }
}