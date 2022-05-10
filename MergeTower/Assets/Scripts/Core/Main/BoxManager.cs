using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class BoxManager : MonoBehaviour
    {
        private static Dictionary<Type, object> data = new Dictionary<Type, object>();

        private static GameSettings gameSettings;
        private static SCRO_SceneManagers sceneManagers;

        private static bool isLogging = false;
        public static bool GetIsLogging { get => isLogging; }

        #region INIT

        public static void Init(SCRO_SceneManagers sceneManagers,bool isLogging)
        {
            BoxManager.sceneManagers = sceneManagers;
            BoxManager.isLogging = isLogging;

            Coroutines.StartRoutine(InitGameRoutine());
        }

        private static IEnumerator InitGameRoutine()
        {
            CreateManagers();
            yield return null;

            InitManagers();
            yield return null;

            StartManagers();
            yield return null;
        }

        private static void CreateManagers()
        {
            foreach (var manager in sceneManagers.GetManagers)
            {
                var add = Instantiate(manager);

                data.Add(add.GetType(), add);
            }
        }

        private static void InitManagers()
        {
            foreach (var manager in data.Values)
            {
                (manager as BaseManager).OnInitialize();
            }
        }

        private static void StartManagers()
        {
            foreach (var manager in data.Values)
            {
                (manager as BaseManager).OnStart();
            }
        }

        #endregion

        public static T GetManager<T>()
        {
            object manager;
            data.TryGetValue(typeof(T), out manager);
            return (T)manager;
        }
    }
}
