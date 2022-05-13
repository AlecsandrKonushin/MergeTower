using ObjectsOnScene;
using SystemTarget;

public class TargetEnemySystem : TargetSystem
{
    public void ChooseTarget()
    {
        target = SceneObjects.Instance.GetGoldHeap;
    }
}