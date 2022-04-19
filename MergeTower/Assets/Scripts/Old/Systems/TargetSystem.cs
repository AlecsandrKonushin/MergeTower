using System;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    private Action<Enemy> waitTargetEnemy;

    private Enemy targetEnemy;

    public void SubscribeOnGetTargetEnemy(Action<Enemy> function)
    {
        ChooseEnemyTarget();

        if(targetEnemy != null)
        {
            function.Invoke(targetEnemy);
        }
        else
        {
            waitTargetEnemy = function;
        }
    }

    public void ChooseEnemyTarget()
    {
        targetEnemy = BoxControllers.GetController<ControllerEnemies>().GetFirstEnemy();

        if (targetEnemy == null)
        {
            Debug.Log($"Нет цели для Tower. Enemy = null");

            BoxControllers.GetController<ControllerEnemies>().EventNewEnemy += TargetAppeared;
        }
    }

    private void TargetAppeared(Enemy enemy)
    {
        BoxControllers.GetController<ControllerEnemies>().EventNewEnemy -= TargetAppeared;
        targetEnemy = enemy;

        if (waitTargetEnemy != null)
        {
            waitTargetEnemy.Invoke(targetEnemy);
            waitTargetEnemy = null;
        }
    }
}
