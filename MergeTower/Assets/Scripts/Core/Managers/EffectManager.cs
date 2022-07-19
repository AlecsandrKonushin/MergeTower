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
            EffectBase effect = ChooseEffect(typeEffect);

            if (effect != null)
            {
                BoxManager.GetManager<CreatorManager>().CreateEffect(effect, transformPosition);
            }
        }

        private EffectBase ChooseEffect(TypeEffect typeEffect)
        {
            EffectBase currentEffect = null;

            foreach (var effect in effects)
            {
                if(effect.GetTypeEffect == typeEffect)
                {
                    currentEffect = effect;
                    currentEffect.AfterShowEffect += EndedEffect;
                    currentEffect.ShowEffect();
                }
            }

            if(currentEffect == null)
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