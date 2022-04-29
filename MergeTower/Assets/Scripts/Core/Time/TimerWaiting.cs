using UnityEngine;

namespace Core
{
    public class TimerWaiting : MonoBehaviour // TODO: прочитать про IDispose
    {
        private IWaiting waiting;
        private float time;

        private bool isBusy;
        private bool timeGo;

        public bool GetIsBusy { get => isBusy; }

        public void SetDataTimer(IWaiting waiting, float time)
        {
            this.waiting = waiting;
            this.time = time;

            timeGo = true;
            isBusy = true;
        }

        private void Update()
        {
            if (timeGo)
            {
                time -= Time.deltaTime;

                if (time <= 0)
                {
                    timeGo = false;

                    waiting.TimeCome();

                    isBusy = false;
                }
            }
        }
    }
}