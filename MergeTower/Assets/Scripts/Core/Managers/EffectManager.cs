using SystemEffect;
using UnityEngine;
using System.Collections.Generic; // Не нужная библиотека

namespace Core
{
    [CreateAssetMenu(fileName = "EffectManager", menuName = "Managers/EffectManager")]
    public class EffectManager : BaseManager 
    {
        [SerializeField] private EffectBase[] typeEffects;
             
        public void SetEffect(TypeEffect typeEffect, Transform transformSpawn)
        {
            CreatorManager creatorManager = BoxManager.GetManager<CreatorManager>();
            int typeEffectIndex = (int)typeEffect;
            EffectBase effect = creatorManager.CreateEffect(typeEffects[typeEffectIndex], transformSpawn); // Добавить EffectBase поле TypeEffect и искать по этому полю, а не по индексу

            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();
        }

        private void EndedEffect(EffectBase effect)
        {
            effect.HideEffect();
        }
    }

    public enum TypeEffect
    {
        StartBulletEffect,
        HitBulletEffect,
        SpawnEffect,
    }
}