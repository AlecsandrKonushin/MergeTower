using SystemMove;
using Core;
using SystemTarget;

namespace ObjectsOnScene
{
    public class Enemy : ObjectScene
    {
        private MoveObjectSystem moveSystem;
        private TargetEnemySystem targetSystem;

        public override void OnInitialize()
        {
            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            targetSystem = new TargetEnemySystem();
            targetSystem.ChooseTarget();

            UpdateGame.Instance.AddMoveObject(moveSystem);
        }
    }
}