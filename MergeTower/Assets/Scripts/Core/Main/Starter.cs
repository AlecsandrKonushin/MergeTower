using UI;
using UnityEngine;
using ObjectsOnScene;

namespace Core
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging;

        private void Start()
        {
            // TODO: сделать OnStart UIManager и SceneObjects
            UIManager.Instance.OnInitialize();
            SceneObjects.Instance.OnInitialize();
            BoxManager.Init(sceneManagers, isLogging);
        }
    }
}
