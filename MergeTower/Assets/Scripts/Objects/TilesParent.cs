using System.Collections.Generic;
using UnityEngine;

public class TilesParent : Singleton<TilesParent>
{
    private Tile[] tiles;

    private List<Tile> freeTiles = new List<Tile>();

    protected override void AfterAwaik()
    {
        tiles = GetComponentsInChildren<Tile>();
        freeTiles.AddRange(tiles);
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
