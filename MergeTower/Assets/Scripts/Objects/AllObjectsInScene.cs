using UnityEngine;

namespace ObjectsOnScene
{
    public class AllObjectsInScene : Singleton<AllObjectsInScene>, IInitialize
    {
        // TODO: Оставить только позиции для спауна на сцене. Tiles удалить и сделать их спаун в старте
        [SerializeField] TilesParent tilesParent;
        [SerializeField] private GameObject spawnEnemyPosition;
        [SerializeField] private ObjectScene[] enemyPositions;

        public TilesParent GetTilesParent { get => tilesParent; }
        public GameObject GetSpawnEnemyPosition { get => spawnEnemyPosition; }

        public void OnInitialize()
        {
            tilesParent.OnInitialize();
        }

        public void OnStart() { }

        public ObjectScene GetEnemyPosition(int numberPos, out bool endPos)
        {
            if (enemyPositions.Length > numberPos)
            {
                endPos = false;
                return enemyPositions[numberPos];
            }
            else
            {
                endPos = true;
                return null;
            }
        }
    }
}