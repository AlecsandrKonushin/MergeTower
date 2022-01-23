using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// В Awake записывает в ToolBox все managers, выбранные в инспекторе
/// </summary>
public class StarterGame : MonoBehaviour
{
    [SerializeField] private List<ControllerBase> controllers;

    private void Start()
    {
        foreach (var controller in controllers)
        {
            BoxControllers.AddController(controller);
        }

        BoxControllers.InitControllers();

        BoxControllers.GetController<ControllerGame>().StartGame();

        StartCoroutine(CoSpawnEnemies());
    }


    private IEnumerator CoSpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            BoxControllers.GetController<ControllerEnemies>().CreateEnemy();
        }
    }
}
