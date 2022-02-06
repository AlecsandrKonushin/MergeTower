public class Enemy : ObjectScene
{
    private MoveSystem moveSystem;

    public override void InitObject()
    {
        moveSystem = gameObject.AddComponent<MoveSystem>();

        moveSystem.SetPositionForChange(PositionsScene.Instance.GetTargetEnemyPos.transform);

        UpdateController.Instance.AddMoveObject(moveSystem);
    }
}
