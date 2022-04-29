using UnityEngine;

namespace MoveSystem
{
    public class RotationObjectSystem : ChangeTransformSystem
    {
        protected override void ChangeTransform()
        {
            if (targetTransform != null)
            {
                Vector3 LookPosition = new Vector3(targetTransform.transform.position.x, this.transform.position.y, targetTransform.transform.position.z);

                transform.LookAt(LookPosition);
            }
            else
            {
                EndChangeTransform();
            }
        }
    }
}