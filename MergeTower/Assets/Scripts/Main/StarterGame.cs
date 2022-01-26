﻿using System.Collections.Generic;
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
    }
}
