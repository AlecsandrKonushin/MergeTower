using UI;
using UnityEngine;
using ObjectsOnScene;

namespace Core
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private SCRO_SceneManagers sceneManagers;
        [SerializeField] private bool isLogging;

        [SerializeField] private UIManager uiManager; 

        private void Start()
        {
            AllObjectsInScene.Instance.OnInitialize();
            BoxManager.Init(sceneManagers, isLogging);

            UIManager.Instance.OnInitialize();
            UIManager.Instance.OnStart();
        }
    }
}
