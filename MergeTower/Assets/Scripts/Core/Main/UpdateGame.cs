using System;
using UnityEngine;

namespace GameUpdate
{
    public class UpdateGame : MonoBehaviour
    {
        public event Action NewFrame;

        private void Update()
        {
            NewFrame?.Invoke();
        }

        public void SubscribeOnUpdate(Action newFrame)
        {
            NewFrame += newFrame;
        }

        public void UnSubscribeOnUpdate(Action newFrame)
        {
            NewFrame -= newFrame;
        }
    }
}