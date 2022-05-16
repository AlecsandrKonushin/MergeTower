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
            targetSystem = new TargetEnemySystem();
            targetSystem.ChooseTarget();

            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            moveSystem.SetTransformForChange(targetSystem.GetTarget.transform);
        }

        public override void Death()
        {
            DeathInvoke();
        }
    }
}