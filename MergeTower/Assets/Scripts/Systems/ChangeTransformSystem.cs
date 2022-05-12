using UnityEngine;
using UnityEngine.Events;

namespace SystemMove
{
    public class ChangeTransformSystem : MonoBehaviour, IMove
    {
        public UnityEvent ListenerEndChange;

        // TODO: устанавливать скорость в конструкторе
        protected float speedChange = 5f;
        protected Transform targetTransform;

        protected bool canChange;

        public void Move()
        {
            if (canChange)
            {
                if (targetTransform != null)
                {
                    ChangeTransform();
                }
                else
                {
                    EndChangeTransform();
                }
            }
        }

        public void SetTransformForChange(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
            SetData();
            canChange = true;
        }

        protected virtual void ChangeTransform() { }
        protected virtual void SetData() { }

        protected void EndChangeTransform()
        {
            canChange = false;
            ListenerEndChange?.Invoke();
        }
    }
}