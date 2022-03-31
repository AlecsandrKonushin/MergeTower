using UnityEngine;

public class BaseManager : ScriptableObject, IManager
{
    public virtual void OnInitialize() { }

    public virtual void OnStart() { }
}
