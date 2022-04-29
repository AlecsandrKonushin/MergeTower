using UnityEngine;

namespace Core
{
    public class BaseManager : ScriptableObject, IManager
    {
        public virtual void OnInitialize() { }

        public virtual void OnStart() { }
    }
}