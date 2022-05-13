using Core;
using System;
using UnityEngine;

namespace SystemTarget
{
    public class TargetTowerSystem : TargetSystem
    {
        protected Action<ObjectScene> waitTarget;

        public void SubscribeOnGetTarget(Action<ObjectScene> function)
        {
            ChooseTarget();

            if (target != null)
            {
                function.Invoke(target);
            }
            else
            {
                waitTarget = function;
            }
        }

        private void ChooseTarget()
        {
            target = BoxManager.GetManager<EnemiesManager>().GetFirstEnemy();

            if (target == null)
            {
                Debug.Log($"Нет цели для Tower. Enemy = null");

                BoxManager.GetManager<EnemiesManager>().NewEnemy += WaitTarget;
            }
        }

        private void WaitTarget(ObjectScene objectScene)
        {
            BoxManager.GetManager<EnemiesManager>().NewEnemy -= WaitTarget;
            target = objectScene ;

            if (waitTarget != null)
            {
                waitTarget.Invoke(target);
                waitTarget = null;
            }
        }
    }
}