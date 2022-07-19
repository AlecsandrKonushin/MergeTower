using SystemEffect;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EffectManager", menuName = "Managers/EffectManager")]
    public class EffectManager : BaseManager
    {
        [SerializeField] private EffectBase startBulletEffect;
        [SerializeField] private EffectBase hitBulletEffect;
        [SerializeField] private EffectBase spawnEffect;

        private void Effect(EffectBase effects, Transform transformSpawn, TypeEffect typeEffect)
        {
            CreatorManager creatorManager = BoxManager.GetManager<CreatorManager>();
            EffectBase effect = creatorManager.CreateEffect(effects, transformSpawn, typeEffect);
            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();
        }
        public void SetEffect(TypeEffect typeEffect, Transform transformSpawn)
        {
            switch (typeEffect)
            {
                case TypeEffect.StartBulletEffect:
                    Effect(startBulletEffect, transformSpawn, typeEffect);
                    break;
                case TypeEffect.HitBulletEffect:
                    Effect(hitBulletEffect, transformSpawn, typeEffect);
                    break;
                case TypeEffect.SpawnEffect:
                    Effect(spawnEffect, transformSpawn, typeEffect);
                    break;
            }
        }
        
        private void EndedEffect(EffectBase effect)
        { 
            effect.HideEffect();
        }
    }
}