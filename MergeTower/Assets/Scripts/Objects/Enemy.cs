using SystemMove;
using Core;
using SystemTarget;

namespace ObjectsOnScene
{
    public class Enemy : ObjectScene
    {
        private MoveObjectSystem moveSystem;
        private TargetSystem targetSystem;

        public override void OnInitialize()
        {
            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            targetSystem = new TargetEnemySystem();

            UpdateGame.Instance.AddMoveObject(moveSystem);
        }
    }
}