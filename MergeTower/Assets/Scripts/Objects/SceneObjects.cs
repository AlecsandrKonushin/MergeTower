using UnityEngine;

namespace ObjectsOnScene
{
    public class SceneObjects : Singleton<SceneObjects>, IInitialize
    {
        // TODO: �������� ������ ������� ��� ������ �� �����. Tiles ������� � ������� �� ����� � ������
        [SerializeField] TilesParent tilesParent;
        [SerializeField] private ObjectScene spawnEnemyPosition;
        [SerializeField] private ObjectScene targetEnemyPosition;

        public TilesParent GetTilesParent { get => tilesParent; }
        public ObjectScene GetSpawnEnemyPosition { get => spawnEnemyPosition; }
        public ObjectScene GetTargetEnemyPosition { get => targetEnemyPosition; }

        public void OnInitialize()
        {
            tilesParent.OnInitialize();
        }

        public void OnStart() { }
    }
}