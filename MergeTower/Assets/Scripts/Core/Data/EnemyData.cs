using System;

namespace Data
{
    public class EnemyData
    {
        public event Action EndHealth;

        private int health;
        private float speed;
        private int priceReward;

        public int GetHealth { get => health; }
        public float GetSpeed { get => speed; }
        public int GetPriceReward { get => priceReward; }

        public EnemyData(int health, float speed, int priceReward)
        {
            this.health = health;
            this.speed = speed;
            this.priceReward = priceReward;
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