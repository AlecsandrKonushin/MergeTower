using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIController : Singleton<UIController>, IInitialize
    {
        private Dictionary<Type, UIWindow> windows;

        #region INITIALIZE

        public void OnInitialize()
        {
            UIWindow[] getWindows = GetComponentsInChildren<UIWindow>();
            windows = new Dictionary<Type, UIWindow>();

            foreach (var window in getWindows)
            {
                windows.Add(window.GetType(), window);
            }

            foreach (var window in windows)
            {
                window.Value.OnInitialize();
            }
        }

        public void OnStart()
        {
            foreach (var window in windows)
            {
                window.Value.OnStart();
            }
        }

        #endregion INITIALIZE

        #region SHOW/HIDE

        public void ShowWindow<T>() where T : UIWindow
        {
            if(windows.TryGetValue(typeof(T) ,out var window))
            {
                window.Show();
            }
            else
            {
                Debug.Log($"<color=red>Нет окна {typeof(T)}, для показа!");
            }
        }

        public void HideWindow<T>() where T : UIWindow
        {
            if (windows.TryGetValue(typeof(T), out var window))
            {
                window.Hide();
            }
            else
            {
                Debug.Log($"<color=red>Нет окна {typeof(T)}, для закрытия!");
            }
        }

        #endregion SHOW/HIDE
    }
}