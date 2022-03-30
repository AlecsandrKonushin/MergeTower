using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class BoxManager
    {
        public static GameSettings gameSettings { get; private set; }

        public static bool IsLogging = false;

        public static void Init(bool isLogging)
        {
            IsLogging = isLogging;

            Coroutines.StartRoutine(InitGameRoutine());
        }

        private static IEnumerator InitGameRoutine()
        {
            InitGameSettings();
            yield return null;


        }

        private static void InitGameSettings()
        {
            gameSettings = new GameSettings();
        }
    }
}
