using UnityEngine;

namespace ObjectsOnScene
{
    public class SceneObjects : Singleton<SceneObjects>, IInitialize
    {
        // TODO: �������� ������ ������� ��� ������ �� �����. Tiles ������� � ������� �� ����� � ������
        [SerializeField] TilesParent tilesParent;
        [SerializeField] private GameObject spawnEnemyPosition;
        [SerializeField] private GoldHeap goldHeap;

        public TilesParent GetTilesParent { get => tilesParent; }
        public GameObject GetSpawnEnemyPosition { get => spawnEnemyPosition; }
        public ObjectScene GetGoldHeap { get => goldHeap; }

        public void OnInitialize()
        {
            tilesParent.OnInitialize();
        }

        public void OnStart() { }
    }
}