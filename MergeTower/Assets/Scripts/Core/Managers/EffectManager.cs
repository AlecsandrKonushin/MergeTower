using SystemEffect;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EffectManager", menuName = "Managers/EffectManager")]
    public class EffectManager : BaseManager
    {
        [SerializeField] private EffectBase startBulletEffect;
        [SerializeField] private EffectBase hitBulletEffect;

        public void StartBulletEffect(Transform transformSpawn)
        {
            EffectBase effect = BoxManager.GetManager<CreatorManager>().CreateEffect(startBulletEffect, transformSpawn);
            effect.AfterShowEffect += EndedEffect;
            effect.ShowEffect();
        }

        public void HitBulletEffect(Vector3 position)
        {

        }

        private void EndedEffect(EffectBase effect)
        {
            effect.HideEffect();
        }
    }
}