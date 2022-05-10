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
            // TODO: ������� OnStart UIManager � SceneObjects
            UIManager.Instance.OnInitialize();
            SceneObjects.Instance.OnInitialize();
            BoxManager.Init(sceneManagers, isLogging);
        }
    }
}
