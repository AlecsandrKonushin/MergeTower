using System.Collections;
using UnityEngine;

namespace Core
{
    public class Coroutines : MonoBehaviour
    {
        private static Coroutines Instance => GetInstance();
        private static Coroutines instance;

        private static Coroutines GetInstance()
        {
            if (instance == null)
            {
                CreateCoroutines();
            }

            return instance;
        }

        private static Coroutines CreateCoroutines()
        {
            instance = new GameObject(NamesData.CoroutinesName).AddComponent<Coroutines>();
            instance.hideFlags = HideFlags.HideAndDontSave;
            return instance;
        }

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return Instance.StartCoroutine(enumerator);
        }
    }
}