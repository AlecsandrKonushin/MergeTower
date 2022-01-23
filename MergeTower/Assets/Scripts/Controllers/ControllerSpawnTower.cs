using UnityEngine;

[CreateAssetMenu(fileName = "ControllerEffects", menuName = "Controllers/ControllerSpawnTower")]
public class ControllerSpawnTower : ControllerBase, IAwake, IListenerBuyTower
{
    public void OnAwake()
    {
        ActionsGame.Instance.AddListenerBuyTower(this);
    }

    public void BuyTower()
    {
        Debug.Log("устанавливаем");
    }

}
