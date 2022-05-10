using System;
using Core;
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
        targetEnemy = BoxManager.GetManager<EnemiesManager>().GetFirstEnemy();

        if (targetEnemy == null)
        {
            Debug.Log($"Нет цели для Tower. Enemy = null");

            BoxManager.GetManager<EnemiesManager>().EventNewEnemy += TargetAppeared;
        }
    }

    private void TargetAppeared(Enemy enemy)
    {
        BoxManager.GetManager<EnemiesManager>().EventNewEnemy -= TargetAppeared;
        targetEnemy = enemy;

        if (waitTargetEnemy != null)
        {
            waitTargetEnemy.Invoke(targetEnemy);
            waitTargetEnemy = null;
        }
    }
}
