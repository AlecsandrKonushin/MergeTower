using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIWindow : UIElement, IUIElement
    {
        public event Action<IUIElement> ClickCloseButton;

        [SerializeField] private Button buttonClose;

        protected void OnClickButtonClick()
        {
            BeforeClickButtonClose();
            Hide();
            AfterClickButtonClose();
        }
    }
}
