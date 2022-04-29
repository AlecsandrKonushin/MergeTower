using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIWindow : UIElement, IUIElement
    {
        public event Action<IUIElement> ClickCloseButton;

        private ButtonClose buttonClose;

        public override void OnStart()
        {
            buttonClose = GetComponentInChildren<ButtonClose>();
        }

        protected void OnClickButtonClose()
        {
            BeforeClickButtonClose();
            Hide();
            AfterClickButtonClose();
        }
    }
}
