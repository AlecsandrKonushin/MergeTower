using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SCRO_SceneManager", menuName = "Architecture/SCRO_SceneManager/New SCRO_SceneManager")]
    public class SCRO_SceneManagers : ScriptableObject
    {
        [SerializeField, ClassReference(typeof(BaseManager))]
        private BaseManager[] managers;

        [HideInInspector]
        public BaseManager[] GetManagers;
    }
}
