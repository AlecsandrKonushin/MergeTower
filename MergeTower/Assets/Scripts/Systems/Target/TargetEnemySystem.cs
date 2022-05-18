using ObjectsOnScene;

namespace SystemTarget
{
    public class TargetEnemySystem : TargetSystem
    {
        private int counterPositions = 0;
        private bool finishPosition;

        public ObjectScene GetTarget { get => target; }
        public bool GetFinishPosition { get => finishPosition; }

        public void ChooseTarget()
        {
            target = AllObjectsInScene.Instance.GetEnemyPosition(counterPositions, out bool endPos);

            if (endPos)
            {
                finishPosition = true;
            }
            else
            {
                finishPosition = false;
                counterPositions++;
            }
        }
    }
}