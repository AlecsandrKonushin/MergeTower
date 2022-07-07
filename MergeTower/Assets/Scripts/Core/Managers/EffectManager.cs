using SystemEffect;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EffectManager", menuName = "Managers/EffectManager")]
    public class EffectManager : BaseManager
    {
        [SerializeField] private EffectBase startBulletEffect;
        [SerializeField] private EffectBase hitBulletEffect;
        [SerializeField] private EffectBase spawnEffect; // спаун пишется не так

        public void StartBulletEffect(Transform transformSpawn)
        {
            EffectBase effect = BoxManager.GetManager<CreatorManager>().CreateEffect(startBulletEffect, transformSpawn);
            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();            
        }        

        public void HitBulletEffect(Transform transformSpawn)
        {
            EffectBase effect = BoxManager.GetManager<CreatorManager>().CreateEffect(hitBulletEffect, transformSpawn);
            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();            
        }
        public void SpownEffect(Transform transformSpown)
        {
            EffectBase effect = BoxManager.GetManager<CreatorManager>().CreateEffect(spawnEffect, transformSpown);
            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();
        }

        private void EndedEffect(EffectBase effect)
        {
            effect.HideEffect();
        }
    }
}