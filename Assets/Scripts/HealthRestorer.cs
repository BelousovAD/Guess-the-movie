using System;
using Currency;
using Timer;

public class HealthRestorer : IDisposable
{
    private readonly TimerRunner _timerRunner;
    private readonly Health _health;
    private readonly float _secondsBetweenRecover;

    public Timer.Timer Timer { get; private set; }
    
    public HealthRestorer(TimerRunner timerRunner, Health health, float secondsBetweenRecover)
    {
        _timerRunner = timerRunner;
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