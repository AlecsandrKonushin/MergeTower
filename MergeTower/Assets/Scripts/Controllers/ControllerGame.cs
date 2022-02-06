using UnityEngine;

[CreateAssetMenu(fileName = "ControllerGame", menuName = "Controllers/ControllerGame")]
public class ControllerGame : ControllerBase
{
    public void StartGame()
    {
        StatesGame.Instance.SetCanMove = true;
        BoxControllers.GetController<ControllerEnemies>().StartSpawn();
    }
}
