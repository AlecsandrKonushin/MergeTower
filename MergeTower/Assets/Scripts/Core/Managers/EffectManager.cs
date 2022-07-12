using SystemEffect;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    [CreateAssetMenu(fileName = "EffectManager", menuName = "Managers/EffectManager")]
    public class EffectManager : BaseManager 
    {
        [SerializeField] private EffectBase[] typeEffects;

        public enum TypeEffect 
        {
            StartBulletEffect,
            HitBulletEffect,
            SpawnEffect,
        }
             
        public void SetEffect(TypeEffect typeEffect, Transform transformSpawn)
        {
            CreatorManager creatorManager = BoxManager.GetManager<CreatorManager>();
            int typeEffectIndex = (int)typeEffect;
            EffectBase effect = creatorManager.CreateEffect(typeEffects[typeEffectIndex], transformSpawn);
            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();
        }

        private void EndedEffect(EffectBase effect)
        {
            effect.HideEffect();
        }
    }
}