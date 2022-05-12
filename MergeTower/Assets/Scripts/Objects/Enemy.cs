using SystemMove;
using Core;

public class Enemy : ObjectScene
{
    private MoveObjectSystem moveSystem;

    public override void OnInitialize()
    {
        moveSystem = gameObject.AddComponent<MoveObjectSystem>();

        moveSystem.SetTransformForChange(PositionsScene.Instance.GetTargetEnemyPos.transform);

       // UpdateGame.Instance.AddMoveObject(moveSystem);
    }
}
