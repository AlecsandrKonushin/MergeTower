using UnityEngine;

namespace SystemMove
{
    public class MoveObjectSystem : ChangeTransformSystem
    {
        private Vector3 targetPosition;

        protected override void SetData()
        {
            targetPosition = targetTransform.position;
        }

        protected override void ChangeTransform()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedChange * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                EndChangeTransform();
            }
        }
    }
}
