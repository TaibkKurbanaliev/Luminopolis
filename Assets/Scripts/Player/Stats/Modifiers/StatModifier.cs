using System;

public abstract class StatModifier : IDisposable
{
    public bool MarkedForRemoval { get; private set; }
    public abstract float Perform(float value, StatType type);

    private readonly CountdownTimer _timer;

    public StatModifier(float duration)
    {
        if (duration <= 0)
            return;

        _timer = new CountdownTimer(duration);
        _timer.TimerFinished += Dispose;
    }

    public void Dispose()
    {
        MarkedForRemoval = true;
    }

}