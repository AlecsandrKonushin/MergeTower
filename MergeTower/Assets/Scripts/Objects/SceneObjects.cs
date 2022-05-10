using UnityEngine;

namespace ObjectsOnScene
{
    public class SceneObjects : Singleton<SceneObjects>, IInitialize
    {
        // TODO: Оставить только позиции для спауна на сцене. Tiles удалить и сделать их спаун в старте
        [SerializeField] TilesParent tilesParent;
        [SerializeField] private GameObject spawnEnemyPosition;
        [SerializeField] private GameObject targetEnemyPosition;

        public TilesParent GetTilesParent { get => tilesParent; }
        public GameObject GetSpawnEnemyPosition { get => spawnEnemyPosition; }
        public GameObject GetTargetEnemyPosition { get => targetEnemyPosition; }

        public void OnInitialize()
        {
            tilesParent.OnInitialize();
        }

        public void OnStart() { }
    }
}