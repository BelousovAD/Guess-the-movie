using System;
using Currency;

public class HealthRestorer : IDisposable
{
    private const int RecoveryAmount = 1;
    
    private readonly Health _health;
    private readonly float _secondsBetweenRecover;

    public Timer.Timer Timer { get; }
    
    public HealthRestorer(Health health, float secondsBetweenRecover)
    {
        _health = health;
        _secondsBetweenRecover = secondsBetweenRecover;
        Timer = new Timer.Timer(true);
        
        _health.Changed += StartRecoveryTimer;
        _health.MaxValueChanged += StartRecoveryTimer;
        Timer.Completed += RecoverHealth;
        StartRecoveryTimer();
    }

    public void Dispose()
    {
        _health.Changed -= StartRecoveryTimer;
        _health.MaxValueChanged -= StartRecoveryTimer;
        Timer.Completed -= RecoverHealth;
    }

    private void StartRecoveryTimer()
    {
        if (_health.Value < _health.MaxValue && Timer.IsDone)
        {
            Timer!.Restart(_secondsBetweenRecover);
        }
    }

    private void RecoverHealth() =>
        _health.Earn(RecoveryAmount);
}