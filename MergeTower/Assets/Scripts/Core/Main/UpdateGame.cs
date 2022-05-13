using System.Collections.Generic;
using SystemMove;
using SystemShoot;

namespace Core
{
    public class UpdateGame : Singleton<UpdateGame>, IInitialize
    {
        private List<IMove> moveObjects = new List<IMove>();
        private List<IShoot> shootObjects = new List<IShoot>();
        private Timer timer;

        private bool isCanMove;
        private bool isCanShoot;
        private bool isCanSpawn;
        private bool isTimeGo;

        public bool SetCanMove { set => isCanMove = value; }
        public bool SetCanShoot { set => isCanShoot = value; }
        public bool SetCanSpawn { set => isCanSpawn = value; }
        public bool SetTimeGo { set => isTimeGo = value; }

        public void OnInitialize()
        {
            timer = Timer.instance;
        }

        public void OnStart() { }

        private void Update()
        {
            if (isCanMove)
            {
                foreach (var moveObject in moveObjects)
                {
                    moveObject.Move();
                }
            }

            if (isCanShoot)
            {
                foreach (var shootObject in shootObjects)
                {
                    shootObject.Shoot();
                }
            }

            if (isTimeGo)
            {
                timer.TickTimer();
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