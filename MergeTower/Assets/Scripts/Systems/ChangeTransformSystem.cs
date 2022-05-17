using Core;
using UnityEngine;
using UnityEngine.Events;

namespace SystemMove
{
    public class ChangeTransformSystem : MonoBehaviour, IMove
    {
        [HideInInspector]
        public UnityEvent ListenerEndChange;

        // TODO: устанавливать скорость в конструкторе
        protected float speedChange = 3f;
        protected Transform targetTransform;

        protected bool canChange;

        public float SetSpeed { set => speedChange = value; }

        private void Awake()
        {
            BoxManager.GetManager<UpdateManager>().AddMoveObject(this);
        }

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

        public void StopMove()
        {
            canChange = false;

            if (ListenerEndChange != null)
            {
                ListenerEndChange.RemoveAllListeners();
            }
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