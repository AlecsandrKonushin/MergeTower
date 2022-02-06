using UnityEngine;

public class MoveSystem : MonoBehaviour, IMove
{
    private IListenerEndMove listenerEndMove;

    private float speedMove = 5f;
    private Vector3 targetPosition;

    private bool canMove;

    public void Move()
    {
        if (canMove)
        {
            Debug.Log($"target pos = {targetPosition}");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedMove * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                canMove = false;
                listenerEndMove.EndMove();
            }
        }
    }

    public void SetPositionForMove(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;

        canMove = true;
    }

    public void SetListenerEndMove(IListenerEndMove listener)
    {
        listenerEndMove = listener;
    }
}
