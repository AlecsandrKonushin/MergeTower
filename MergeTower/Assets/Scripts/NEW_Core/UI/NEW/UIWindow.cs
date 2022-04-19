using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIWindow : UIElement, IUIElement
    {
        #region EVENTS

        public event Action<IUIElement> ClickCloseButton;

        #endregion

        [SerializeField] private GameObject background;
        [SerializeField] private Button buttonClose;

        public override void Show()
        {
            if (IsActive)
            {
                Debug.Log($"<color=red>Вызывается показ окна {gameObject.GetType()}, а оно уже открыто!");
                return;
            }
            else
            {
                IsActive = true;
                BeforeShow();
            }
        }

        public override void Change()
        {
        }

        public override void Hide()
        {
            if (!IsActive)
            {
                Debug.Log($"<color=red>Вызывается сокрытия окна {gameObject.GetType()}, а оно уже закрыто!");
                return;
            }
            else
            {
                IsActive = false;
                BeforeHide();
            }
        }

        protected void OnClickButtonClick()
        {
            BeforeClickButtonClose();
            Hide();
            AfterClickButtonClose();
        }

        protected virtual void BeforeClickButtonClose() { }
        protected virtual void AfterClickButtonClose() { }
        protected virtual void BeforeShow() { }
        protected virtual void AfterShow() { }
        protected virtual void BeforeHide() { }
        protected virtual void AfterHide() { }

    }
}
