using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : Singleton<Creator>, IInitialize
{
    private GameObject managers;

    public void OnInitialize()
    {
       // managers = Instantiate(new GameObject());
    }

    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public static void CreateManager()
    {

    }
}
