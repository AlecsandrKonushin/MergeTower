using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "TimeManager", menuName = "Managers/TimeManager")]
    public class TimeManager : BaseManager, IWaiting
    {
        private List<IWaiting> waitingObjects = new List<IWaiting>();

        public void AddWaitingObject(IWaiting waitingObject)
        {
            waitingObjects.Add(waitingObject);
        }

        public void RemoveWaitingObject(IWaiting waitingObject)
        {
            if (waitingObjects.Contains(waitingObject))
            {
                waitingObjects.Remove(waitingObject);
            }
        }

        public void TickTimer()
        {
            if (waitingObjects.Count > 0)
            {
                foreach (var waitingObject in waitingObjects)
                {
                    waitingObject.TickTimer();
                }
            }
        }
    }
}