using System.Collections.Generic;

public class TimeController : Singleton<TimeController>
{
    private List<TimerWaiting> timersWaiting = new List<TimerWaiting>();

    public void AddWaiting(IWaiting waiting, float time)
    {
        TimerWaiting currentTimer = null;

        if (timersWaiting.Count > 0)
        {
            foreach (var timer in timersWaiting)
            {
                if (!timer.GetIsBusy)
                {
                    currentTimer = timer;
                }
            }
        }

        if (currentTimer == null)
        {
            currentTimer = gameObject.AddComponent<TimerWaiting>();
            timersWaiting.Add(currentTimer);
        }

        currentTimer.SetDataTimer(waiting, time);
    }
}
