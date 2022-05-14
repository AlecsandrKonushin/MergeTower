using System.Collections.Generic;
using SystemMove;
using SystemShoot;
using UnityEngine;
using GameUpdate;

namespace Core
{
    [CreateAssetMenu(fileName = "UpdateManager", menuName = "Managers/UpdateManager")]
    public class UpdateManager : BaseManager
    {
        private UpdateGame updateGame;

        private List<IMove> moveObjects = new List<IMove>();
        private List<IShoot> shootObjects = new List<IShoot>();
        private TimeManager timer;

        private bool isCanMove;
        private bool isCanShoot;
        private bool isTimeGo;

        public bool SetCanMove { set => isCanMove = value; }
        public bool SetCanShoot { set => isCanShoot = value; }
        public bool SetTimeGo { set => isTimeGo = value; }

        public override void OnInitialize()
        {
            GameObject newObject = new GameObject();
            newObject.name = NamesData.UpdateGameName;

            updateGame = newObject.gameObject.AddComponent<UpdateGame>();

            timer = BoxManager.GetManager<TimeManager>();
            isTimeGo = true;
        }

        public override void OnStart()
        {
            updateGame.SubscribeOnUpdate(NewFrame);
        }

        private void NewFrame()
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
                if (timer != null)
                {
                    timer.TickTimer();
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