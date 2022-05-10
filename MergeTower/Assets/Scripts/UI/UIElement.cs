using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public abstract class UIElement : MonoBehaviour, IUIElement, IInitialize
    {
        public bool IsActive { get; protected set; }

        #region EVENTS

        [HideInInspector]
        public UnityEvent<IUIElement> EndShow, EndChange, EndHide;

        #endregion

        protected float timeShow;
        protected float timeHide;
        protected float timeChange;

        private Animator animator;
        private bool haveAnimation;

        #region INITIALIZE

        public void OnInitialize()
        {
            SetAnimator();

            if (haveAnimation)
            {
                SetAnimationTime();
            }

            AfterInitialization();
        }

        protected virtual void AfterInitialization() { }

        public virtual void OnStart() { }

        #endregion

        #region SHOW/HIDE

        public void Show()
        {
            if (IsActive)
            {
                Debug.Log($"<color=red>Вызывается показ элемента {gameObject.GetType()}, а оно уже показан!");
                return;
            }
            else
            {
                IsActive = true;
                BeforeShow();

                if (haveAnimation)
                {
                    StartCoroutine(CoShowAnimation(TypeAnimation.Show, () => { AfterAnimationShow(); }));
                }
                else
                {
                    AfterAnimationShow();
                }
            }
        }

        public void Change() { }

        public void Hide()
        {
            if (!IsActive)
            {
                Debug.Log($"<color=red>Вызывается сокрытие элемента {gameObject.GetType()}, а оно уже сокрыт!");
                return;
            }
            else
            {
                IsActive = false;
                BeforeHide();

                if (haveAnimation)
                {
                    StartCoroutine(CoShowAnimation(TypeAnimation.Hide, () => { AfterAnimationHide(); }));
                }
                else
                {
                    AfterAnimationHide();
                }
            }
        }

        private void AfterAnimationShow()
        {
            AfterShow();
            InvokeEndShow();
        }

        private void AfterAnimationHide()
        {
            AfterHide();
            InvokeEndHide();
        }

        protected virtual void BeforeClickButtonClose() { }
        protected virtual void AfterClickButtonClose() { }
        protected virtual void BeforeShow() { }
        protected virtual void AfterShow() { }
        protected virtual void BeforeHide() { }
        protected virtual void AfterHide() { }

        #endregion

        #region INVOKE

        protected void InvokeEndShow()
        {
            EndShow?.Invoke(this);
        }

        protected void InvokeEndHide()
        {
            EndHide?.Invoke(this);
        }

        #endregion

        #region ANIMATION

        private void SetAnimator()
        {
            if(TryGetComponent(out Animator animator))
            {
                this.animator = animator;
                haveAnimation = true;
            }
            else
            {
                haveAnimation = false;
            }
        }

        private void SetAnimationTime()
        {
            AnimationClip[] animations = gameObject.GetComponent<Animator>().runtimeAnimatorController.animationClips;

            foreach (var anim in animations)
            {
                if (anim.name == TypeAnimation.Show.ToString())
                {
                    timeShow = anim.length;
                }
                if (anim.name == TypeAnimation.Hide.ToString())
                {
                    timeHide = anim.length;
                }
                if (anim.name == TypeAnimation.Change.ToString())
                {
                    timeChange = anim.length;
                }
            }
        }

        private IEnumerator CoShowAnimation(TypeAnimation typeAnimation, Action callBack = null)
        {
            animator.SetTrigger(typeAnimation.ToString());
            float timeWait = 0;

            if (typeAnimation == TypeAnimation.Show)
            {
                timeWait = timeShow;
            }
            else if (typeAnimation == TypeAnimation.Hide)
            {
                timeWait = timeHide;
            }
            else if (typeAnimation == TypeAnimation.Change)
            {
                timeWait = timeChange;
            }

            yield return new WaitForSeconds(timeWait);
            callBack?.Invoke();
        }

        #endregion
    }
}
