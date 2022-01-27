using UnityEngine;

public class Enemy : ObjectScene
{
    private MoveSystem moveSystem;

    public override void InitObject()
    {
        moveSystem = new MoveSystem();

        UpdateController.Instance.AddMoveObject(moveSystem);
    }
}
