using System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static event Action PausedApplication;
        public static event Action UnpausedApplication;
        public static event Action FocusedApplication;
        public static event Action UnfocusedApplication;

        [SerializeField] private GameObject obj;
        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            BoxManager.Init(sceneManagers, isLogging);
        }

        private void OnApplicationPause(bool pause)
        {
            if (isLogging)
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
            if (isLogging)
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
    }
}
