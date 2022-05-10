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

        public override void OnStart()
        {
            base.OnStart();
        }

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

        #region STATES_GAME

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

        #endregion STATES_GAME
    }
}