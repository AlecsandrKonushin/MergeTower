using System.Collections.Generic;
using MoveSystem;
using ShootSystem;

namespace Core
{
    public class UpdateGame : Singleton<UpdateGame>
    {
        private List<IMove> moveObjects = new List<IMove>();
        private List<IShoot> shootObjects = new List<IShoot>();

        private bool canMove;
        public bool SetCanMove { set => canMove = value; }

        private void Update()
        {
            if (canMove)
            {
                foreach (var moveObject in moveObjects)
                {
                    moveObject.Move();
                }
            }
        }

        public void AddMoveObject(IMove moveObject)
        {
            moveObjects.Add(moveObject);
        }

        public void RemoveMoveObject(IMove moveObject)
        {
            if (moveObjects.Contains(moveObject))
            {
                moveObjects.Remove(moveObject);
            }
        }

        public void AddShootObject(IShoot shootObject)
        {
            shootObjects.Add(shootObject);
        }

        public void RemoveShootObject(IShoot shootObject)
        {
            if (shootObjects.Contains(shootObject))
            {
                shootObjects.Remove(shootObject);
            }
        }
    }
}