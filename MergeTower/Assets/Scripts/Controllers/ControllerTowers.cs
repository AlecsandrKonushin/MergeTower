using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControllerEffects", menuName = "Controllers/ControllerTowers")]
public class ControllerTowers : ControllerBase, IAwake, IListenerBuyTower
{
    [SerializeField] private Tower[] towerPrefabs;

    private List<Tower> towers= new List<Tower>();

    public void OnAwake()
    {
        ActionsGame.Instance.AddListenerBuyTower(this);
    }

    public void BuyTower()
    {
        Tile tile = TilesParent.Instance.GetTileForSpawnTower();

        if(tile == null)
        {
            return;
        }
        else
        {
            Tower newTower = CreatorObjects.Instance.CreateTower(towerPrefabs[0], tile);

            towers.Add(newTower);
        }
    }

}
