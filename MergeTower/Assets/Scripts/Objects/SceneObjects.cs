using UnityEngine;

namespace ObjectsOnScene
{
    public class SceneObjects : Singleton<SceneObjects>, IInitialize
    {
        [SerializeField] TilesParent tilesParent;

        public TilesParent GetTilesParent { get => tilesParent; }

        public void OnInitialize()
        {
            tilesParent.OnInitialize();
        }

        public void OnStart() { }
    }
}