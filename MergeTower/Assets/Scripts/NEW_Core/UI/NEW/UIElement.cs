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

        public UnityEvent<IUIElement> EndShow;
        public UnityEvent<IUIElement> EndChange;
        public UnityEvent<IUIElement> EndHide;

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
        }

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
                    StartCoroutine(CoShowAnimation(TypeAnimationUI.Show, () => { AfterAnimationShow(); }));
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
                    StartCoroutine(CoShowAnimation(TypeAnimationUI.Show, () => { AfterAnimationHide(); }));
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
                if (anim.name == TypeAnimationUI.Show.ToString())
                {
                    timeShow = anim.length;
                }
                if (anim.name == TypeAnimationUI.Hide.ToString())
                {
                    timeHide = anim.length;
                }
                if (anim.name == TypeAnimationUI.Change.ToString())
                {
                    timeChange = anim.length;
                }
            }
        }

        private IEnumerator CoShowAnimation(TypeAnimationUI typeAnimation, Action callBack = null)
        {
            animator.SetTrigger(typeAnimation.ToString());
            float timeWait = 0;

            if (typeAnimation == TypeAnimationUI.Show)
            {
                timeWait = timeShow;
            }
            else if (typeAnimation == TypeAnimationUI.Hide)
            {
                timeWait = timeHide;
            }
            else if (typeAnimation == TypeAnimationUI.Change)
            {
                timeWait = timeChange;
            }

            yield return new WaitForSeconds(timeWait);
            callBack?.Invoke();
        }

        #endregion
    }
}
