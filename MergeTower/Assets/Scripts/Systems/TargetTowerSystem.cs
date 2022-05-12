using Core;
using UnityEngine;

namespace SystemTarget
{
    public class TargetTowerSystem : TargetSystem
    {
        public override void ChooseTarget()
        {
            target = BoxManager.GetManager<EnemiesManager>().GetFirstEnemy();

            if (target == null)
            {
                Debug.Log($"Нет цели для Tower. Enemy = null");

                BoxManager.GetManager<EnemiesManager>().EventNewEnemy += WaitTarget;
            }
        }

        protected override void WaitTarget(ObjectScene objectScene)
        {
            BoxManager.GetManager<EnemiesManager>().EventNewEnemy -= WaitTarget;
            target = objectScene ;

            if (waitTarget != null)
            {
                waitTarget.Invoke(target);
                waitTarget = null;
            }
        }
    }
}