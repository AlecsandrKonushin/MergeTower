using ObjectsOnScene;

namespace SystemTarget
{
    public class TargetEnemySystem : TargetSystem
    {
        public void ChooseTarget()
        {
            target = SceneObjects.Instance.GetGoldHeap;
        }
    }
}