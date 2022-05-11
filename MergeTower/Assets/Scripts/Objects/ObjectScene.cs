using UnityEngine;

public abstract class ObjectScene : MonoBehaviour, IInitialize
{
    public virtual void OnInitialize() { }

    public virtual void OnStart() { }
}
