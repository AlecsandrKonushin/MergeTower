using System;
using System.Collections;
using UnityEngine;

namespace SystemEffect
{
    public class EffectBase : MonoBehaviour
    {
        [HideInInspector]
        public event Action<EffectBase> AfterShowEffect;

        [SerializeField] private TypeEffect typeEffect;
        [SerializeField] private float timeEffect;

        public TypeEffect GetTypeEffect { get => typeEffect; }

        public void ShowEffect()
        {
            gameObject.SetActive(true);
            
            StartCoroutine(CoShowEffect());
        }

        public void HideEffect()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator CoShowEffect()
        {
            yield return new WaitForSeconds(timeEffect);

            AfterShowEffect?.Invoke(this);
        }
    }
}