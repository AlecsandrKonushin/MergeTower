using System;
using System.Collections;
using UnityEngine;

namespace SystemEffect
{
    public class EffectBase : MonoBehaviour
    {
        [HideInInspector]
        public event Action<EffectBase> AfterShowEffect;

        [SerializeField] private float timeEffect;

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
            if (timeEffect <= 2)
                Destroy(gameObject);
            AfterShowEffect?.Invoke(this);
        }
    }
    public enum TypeEffect
    {
        StartBulletEffect,
        HitBulletEffect,
        SpawnEffect,
    }
}