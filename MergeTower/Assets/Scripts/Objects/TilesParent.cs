using System.Collections.Generic;
using UnityEngine;

namespace ObjectsOnScene
{
    public class TilesParent : MonoBehaviour, IInitialize
    {
        private Tile[] tiles;

        private List<Tile> freeTiles = new List<Tile>();

        public void OnInitialize()
        {
            tiles = GetComponentsInChildren<Tile>();
            freeTiles.AddRange(tiles);
        }

        public void OnStart() { }

        public bool HaveTileForSpawn()
        {
            if (freeTiles.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tile GetTileForSpawnTower()
        {
            Tile tile = null;

            if (freeTiles.Count == 0)
            {
                Debug.Log("Нет свободных tiles для спауна tower");

                return null;
            }

            if (freeTiles.Count == 1)
            {
                tile = freeTiles[0];
            }

            tile = freeTiles[Random.Range(0, freeTiles.Count)];

            freeTiles.Remove(tile);

            return tile;
        }
    }
}