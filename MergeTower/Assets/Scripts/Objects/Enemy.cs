using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MoveSystem moveSystem;

    public Enemy()
    {
        moveSystem = new MoveSystem();

        UpdateController.Instance.AddMoveObject(moveSystem);
    }
}
