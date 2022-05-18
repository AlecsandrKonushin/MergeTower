﻿using Data;
using SystemMove;
using SystemTarget;
using UnityEngine;

namespace ObjectsOnScene
{
    public class Enemy : ObjectScene
    {
        private MoveObjectSystem moveSystem;
        private TargetEnemySystem targetSystem;
        private EnemyData enemyData;

        public EnemyData SetData
        {
            set
            {
                enemyData = value;
                enemyData.EndHealth += Death;
            }
        }

        public override void OnInitialize()
        {
            targetSystem = new TargetEnemySystem();
            targetSystem.ChooseTarget();

            moveSystem = gameObject.AddComponent<MoveObjectSystem>();
            moveSystem.SetSpeed = enemyData.GetSpeed;
            moveSystem.SetTransformForChange(targetSystem.GetTarget.transform);
            moveSystem.EndedChangeTransform += EndMoveToTarget;
        }

        public override void Damage(int value)
        {
            enemyData.DownHealth(value);
        }

        protected override void Death()
        {
            moveSystem.StopMove();

            DeathInvoke();

            gameObject.SetActive(false);
        }

        private void EndMoveToTarget()
        {
            moveSystem.EndedChangeTransform -= EndMoveToTarget;
            targetSystem.ChooseTarget();

            if (targetSystem.GetFinishPosition)
            {
                Attack();
            }
            else
            {
                moveSystem.SetTransformForChange(targetSystem.GetTarget.transform);
                moveSystem.EndedChangeTransform += EndMoveToTarget;
            }
        }

        private void Attack()
        {
            Debug.Log("attack");
        }
    }
}