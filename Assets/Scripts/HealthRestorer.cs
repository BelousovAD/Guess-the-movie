using System;
using Currency;

public class HealthRestorer : IDisposable
{
    private readonly Health _health;
    private readonly float _secondsBetweenRecover;

    public Timer.Timer Timer { get; private set; }
    
    {
        _health = health;
        _secondsBetweenRecover = secondsBetweenRecover;
        
        _health.Changed += StartRecoveryTimer;
        _health.MaxValueChanged += StartRecoveryTimer;
        StartRecoveryTimer();
    }

    public void Dispose()
    {
        _health.Changed -= StartRecoveryTimer;
        _health.MaxValueChanged -= StartRecoveryTimer;
    }

    private void StartRecoveryTimer()
    {
        if (_health.Value < _health.MaxValue && (Timer is null || Timer.IsDone))
        {
            Timer = new Timer.Timer(_timerRunner, true);
            Timer.Restart(_secondsBetweenRecover);
        }
    }
}