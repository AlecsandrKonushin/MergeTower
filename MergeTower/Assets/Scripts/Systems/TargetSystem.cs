using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public delegate void NewTarget(Enemy enemy);
    public event NewTarget EventNewTarget;

    private Enemy targetEnemy;
    public Enemy GetTargetEnemy { get => targetEnemy; }

    public void ChooseEnemyTarget()
    {
        targetEnemy = BoxControllers.GetController<ControllerEnemies>().GetFirstEnemy();

        if(targetEnemy == null)
        {
            Debug.Log($"Нет цели для Tower. Enemy = null");

            BoxControllers.GetController<ControllerEnemies>().EventNewEnemy += SpawnTarget;
        }
    }

    private void SpawnTarget(Enemy enemy)
    {
        BoxControllers.GetController<ControllerEnemies>().EventNewEnemy -= SpawnTarget;
        targetEnemy = enemy;

        EventNewTarget?.Invoke(targetEnemy);
    }
}
