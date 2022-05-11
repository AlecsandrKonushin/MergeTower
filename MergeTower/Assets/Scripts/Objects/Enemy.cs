using MoveSystem;
using Core;

public class Enemy : ObjectScene
{
    private MoveObjectSystem moveSystem;

    public override void OnInitialize()
    {
        moveSystem = gameObject.AddComponent<MoveObjectSystem>();

        moveSystem.SetPositionForChange(PositionsScene.Instance.GetTargetEnemyPos.transform);

       // UpdateGame.Instance.AddMoveObject(moveSystem);
    }
}
