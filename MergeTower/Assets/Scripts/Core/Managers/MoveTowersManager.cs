using SystemTouch;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "MoveTowersManager", menuName = "Managers/MoveTowersManager")]
    public class MoveTowersManager : BaseManager
    {
        private TouchSystem touchSystem;

        public override void OnInitialize()
        {
            GameObject newObject = new GameObject();
            newObject.name = NamesData.TouchSystemName;

            touchSystem = newObject.gameObject.AddComponent<TouchSystem>();
            touchSystem.SetCamera = Camera.main;
        }
    }
}