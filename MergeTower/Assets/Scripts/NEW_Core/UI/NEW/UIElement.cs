using System;
using UnityEngine;

namespace UI
{
    public abstract class UIElement : MonoBehaviour, IUIElement
    {
        public bool IsActive { get; protected set; }

        public event Action<IUIElement> EndShow;
        public event Action<IUIElement> EndChange;
        public event Action<IUIElement> EndHide;

        public virtual void Change() { }
        public virtual void Hide() { }
        public virtual void Show() { }
    }
}
