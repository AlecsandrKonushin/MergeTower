using System;

namespace SystemTarget
{
    public abstract class TargetSystem
    {
        protected Action<ObjectScene> waitTarget;

        protected ObjectScene target;

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

        public abstract void ChooseTarget();

        protected abstract void WaitTarget(ObjectScene objectScene);
    }
}