using System;

namespace UI
{
    public interface IUIElement
    {
        #region EVENTS

        event Action<IUIElement> EndShow;
        event Action<IUIElement> EndChange;
        event Action<IUIElement> EndHide;

        bool IsActive { get; }

        void Show();
        void Change();
        void Hide();

        #endregion
    }
}
