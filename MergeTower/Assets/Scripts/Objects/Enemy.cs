using SystemMove;
using Core;
using SystemTarget;
using System;

namespace ObjectsOnScene
{
    public class Enemy : ObjectScene
    {
        public event Action DeathEnemy;

        private MoveObjectSystem moveSystem;
        private TargetEnemySystem targetSystem;

        public override void OnInitialize()
        {
            targetSystem = new TargetEnemySystem();
            targetSystem.ChooseTarget();

            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            moveSystem.SetTransformForChange(targetSystem.GetTarget.transform);

            BoxManager.GetManager<UpdateManager>().AddMoveObject(moveSystem);
        }

        private void Dearh()
        {
            DeathEnemy?.Invoke();
        }
    }
}