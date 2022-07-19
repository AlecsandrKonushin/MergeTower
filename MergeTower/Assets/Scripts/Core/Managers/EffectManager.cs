using SystemEffect;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "EffectManager", menuName = "Managers/EffectManager")]
    public class EffectManager : BaseManager
    {
        [SerializeField] private EffectBase[] effects;

        public void ShowEffect(TypeEffect typeEffect, Transform transformPosition)
        {
            EffectBase currentEffect = ChooseEffect(typeEffect);

            if (currentEffect != null)
            {
                EffectBase effect = BoxManager.GetManager<CreatorManager>().CreateEffect(currentEffect, transformPosition);

                effect.AfterShowEffect += EndedEffect;
                effect.ShowEffect();
            }
        }

        private EffectBase ChooseEffect(TypeEffect typeEffect)
        {
            EffectBase currentEffect = null;

            foreach (var effect in effects)
            {
                if (effect.GetTypeEffect == typeEffect)
                {
                    currentEffect = effect;
                }
            }

            if (currentEffect == null)
            {
                Debug.Log($"<color=red>Не найден эффект с типом {typeEffect}</color>");
            }

            return currentEffect;
        }

        private void EndedEffect(EffectBase effect)
        {
            effect.HideEffect();
        }
    }
}