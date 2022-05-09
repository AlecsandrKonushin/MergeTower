using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SCRO_SceneManager", menuName = "Architecture/SCRO_SceneManagers/SCRO_SceneManagers")]
    public class SCRO_SceneManagers : ScriptableObject
    {
        [SerializeField, ClassReference(typeof(BaseManager))]
        private BaseManager[] managers;

        [HideInInspector]
        public BaseManager[] GetManagers { get => managers; }
    }
}
