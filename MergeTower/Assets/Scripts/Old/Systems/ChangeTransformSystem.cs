using UnityEngine;

public class ChangeTransformSystem : MonoBehaviour, IMove
{
    protected IListenerEndChange listenerEndChange;

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

    public void SetPositionForChange(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
        SetData();
        canChange = true;
    }

    public void SetListenerEndChange(IListenerEndChange listener)
    {
        listenerEndChange = listener;
    }

    protected virtual void ChangeTransform() { }
    protected virtual void SetData() { }

    protected void EndChangeTransform()
    {
        canChange = false;
        listenerEndChange?.EndMove();
    }
}
