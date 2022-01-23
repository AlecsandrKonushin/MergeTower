using UnityEngine;

public class MoveSystem : MonoBehaviour, IMove
{
    private IListenerEndMove listenerEndMove;

    private Transform transformObject;
    private float speedMove = 5f;
    private Vector3 targetPosition;

    private bool canMove;

    public MoveSystem(GameObject objectMove)
    {
        transformObject = objectMove.transform;
        UpdateController.Instance.AddMoveObject(this);

        canMove = true;
    }

    public void Move()
    {
        if (canMove)
        {
            transformObject.position = Vector3.MoveTowards(transformObject.position, targetPosition, speedMove * Time.deltaTime);

            if (transformObject.position == targetPosition)
            {
                canMove = false;
                listenerEndMove?.EndMove();
            }
        }
    }

    public void SetPositionForMove(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public void SetListenerEndMove(IListenerEndMove listener)
    {
        listenerEndMove = listener;
    }
}
