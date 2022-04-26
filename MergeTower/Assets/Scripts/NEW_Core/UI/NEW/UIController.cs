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

            //foreach (var window in windows)
            //{
            //    window.OnInitialize();
            //}
        }

        public void OnStart()
        {
            //foreach (var window in windows)
            //{
            //    window.OnStart();
            //}
        }

        #endregion INITIALIZE

        public static void ShowWindow<T>() where T : UIWindow
        {

        }
    }
}