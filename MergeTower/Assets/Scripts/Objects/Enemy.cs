using SystemMove;
using Core;
using SystemTarget;

public class Enemy : ObjectScene
{
    private MoveObjectSystem moveSystem;
    private TargetSystem targetSystem;

    public override void OnInitialize()
    {
        moveSystem = gameObject.AddComponent<MoveObjectSystem>();


        UpdateGame.Instance.AddMoveObject(moveSystem);
    }
}
