using UnityEngine;

namespace ObjectsOnScene
{
    public class GoldHeap : ObjectScene
    {
        private int health = 3;

        public void DamageHeap(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Debug.Log("Конец игры!");
            }
        }
    }
}