using System.Collections;
using UnityEngine;

namespace Core
{
    public class Coroutines : MonoBehaviour
    {
        private const string NAME_OBJECT = "[COROUTINES_OBJECT]";

        private static Coroutines instance => GetInstance();
        private static Coroutines m_instance;

        private static Coroutines GetInstance()
        {
            if (m_instance == null)
            {
                CreateCoroutines();
            }

            return m_instance;
        }

        private static Coroutines CreateCoroutines()
        {
            m_instance = new GameObject(NAME_OBJECT).AddComponent<Coroutines>();
            m_instance.hideFlags = HideFlags.HideAndDontSave;
            return m_instance;
        }

        private static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return instance.StartCoroutine(enumerator);
        }
    }
}
