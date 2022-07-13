﻿using Data;
using Core;
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

        public GameObject hitPosition; // 1. Никогда не делать public! Только [SerializeField] private 2. Сделать свойство и через него передавать hitPosition
        public int GetPriceReward { get => enemyData.GetPriceReward; }

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

            BoxManager.GetManager<EffectManager>().SetEffect(TypeEffect.HitBulletEffect, transform);
        }

        protected override void Death()
        {
            moveSystem.StopMove();

            DeathInvoke();
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