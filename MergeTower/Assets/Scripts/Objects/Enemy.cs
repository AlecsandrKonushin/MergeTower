using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MoveSystem moveSystem;

    public void InitEnemy(TypeMove typeMove, Vector3 targetMove)
    {
        if (typeMove == TypeMove.Simple)
        {
            moveSystem = new MoveSystem(gameObject);
        }

        moveSystem.SetPositionForMove(targetMove);
    }
}
