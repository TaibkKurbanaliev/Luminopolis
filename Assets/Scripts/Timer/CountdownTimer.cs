using System;
using UnityEngine;

public class CountdownTimer
{
    public event Action TimerFinished;

    public float Duration { get; private set; }

    public CountdownTimer(float duration)
    {
        Duration = duration;
        TimeInvoker.Instance.OneUnscaledDeltaTimeTiked += OnTimerTicked;
    }

    private void OnTimerTicked(float deltaTime)
    {
        Duration -= deltaTime;

        if (Duration <= 0)
        {
            TimerFinished?.Invoke();
            TimeInvoker.Instance.OneUnscaledDeltaTimeTiked -= OnTimerTicked;
        }  
    }
}
