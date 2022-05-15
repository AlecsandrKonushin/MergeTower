using ObjectsOnScene;

namespace SystemTarget
{
    public class TargetEnemySystem : TargetSystem
    {
        public ObjectScene GetTarget { get => target; }

        public void ChooseTarget()
        {
            target = SceneObjects.Instance.GetGoldHeap;
        }
    }
}