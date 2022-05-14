using ObjectsOnScene;
using System;
using Towers;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
    public class GameManager : BaseManager
    {
        #region ACTIONS

        public static event Action PausedApplication;
        public static event Action UnpausedApplication;
        public static event Action FocusedApplication;
        public static event Action UnfocusedApplication;

        #endregion ACTIONS

        #region STATES_GAME

        public static event Action<bool> ChangeCanMove;
        public static event Action<bool> ChangeCanShoot;
        public static event Action<bool> ChangeCanSpawn;
        public static event Action<bool> ChangeTimeGo;

        public bool CanMove 
        {
            get => canMove;
            private set => ChangeCanMove?.Invoke(value); 
        }

        public bool CanShoot
        {
            get => canShoot;
            private set => ChangeCanShoot?.Invoke(value);
        }

        public bool CanSpawn
        {
            get => canSpawn;
            private set => ChangeCanSpawn?.Invoke(value);
        }

        public bool TimeGo
        {
            get => timeGo;
            private set => ChangeTimeGo?.Invoke(value);
        }

        private bool canMove;
        private bool canShoot;
        private bool canSpawn;
        private bool timeGo;

        #endregion STATES_GAME

        public void ClickBuyTowerButton(TypeTower typeTower)
        {
            if (BoxManager.GetManager<CoinsManager>().CanBuyTower(typeTower))
            {
                if (SceneObjects.Instance.GetTilesParent.HaveTileForSpawn())
                {
                    BoxManager.GetManager<CoinsManager>().BuyTower(typeTower);
                    BoxManager.GetManager<TowersManager>().BuyTower(typeTower);
                }
            }
        }

        #region DO_ACTIONS

        private void OnApplicationPause(bool pause)
        {
            if (BoxManager.GetIsLogging)
            {
                Debug.Log($"Application on pause = {pause}");
            }

            if (pause)
            {
                PausedApplication?.Invoke();
            }
            else
            {
                UnpausedApplication?.Invoke();
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (BoxManager.GetIsLogging)
            {
                Debug.Log($"Application on focus = {focus}");
            }

            if (focus)
            {
                FocusedApplication?.Invoke();
            }
            else
            {
                UnfocusedApplication?.Invoke();
            }
        }

        #endregion DO_ACTIONS
    }
}