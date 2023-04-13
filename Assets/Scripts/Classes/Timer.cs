using System;

public class Timer {
    public float remainingSeconds { get; private set; }
    public Timer(float duration)
    {
        remainingSeconds = duration;
    }

    public event Action OnTimerEnd;

    public void Tick(float deltaTime)
    {
        if (remainingSeconds == 0f) return;

        remainingSeconds -= deltaTime;

        CheckForTimerEnd();
    }

    private void CheckForTimerEnd()
    {
        if (remainingSeconds > 0f) return;

        remainingSeconds = 0f;

        OnTimerEnd?.Invoke();
    }
}
