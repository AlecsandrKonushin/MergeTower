using System;
using UnityEngine;

public abstract class ObjectScene : MonoBehaviour, IInitialize
{
    public event Action DeathObjectEvent;

    public virtual void OnInitialize() { }

    public virtual void OnStart() { }

    public virtual void Damage(int value) { }

    protected virtual void Death() { }

    protected void DeathInvoke()
    {
        DeathObjectEvent?.Invoke();
    }
}
