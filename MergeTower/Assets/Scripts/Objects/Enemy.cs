using UnityEngine;

public class Enemy : ObjectScene
{
    private MoveSystem moveSystem;

    public override void InitObject()
    {
        moveSystem = new MoveSystem();
        moveSystem.SetPositionForMove(PositionsScene.Instance.GetTargetEnemyPos.transform.position);

        UpdateController.Instance.AddMoveObject(moveSystem);
    }
}
