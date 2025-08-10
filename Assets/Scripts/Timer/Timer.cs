namespace Timer
{
    using System;
    using BelousovGameDev.ChangeableValue;
    using UnityEngine;

    public class Timer : ChangeableValue<float>
    {
        private readonly TimerRunner _timerRunner;
        private float _startTime;
        private float _lastUpdateTime;
        
        public Timer(TimerRunner timerRunner, bool usesRealTime = false, bool isLooped = false)
        {
            _timerRunner = timerRunner;
            UsesRealTime = usesRealTime;
            IsLooped = isLooped;
        }

        public event Action Completed;
        
        public float Duration { get; private set; }

        public bool IsLooped { get; }

        public bool UsesRealTime { get; }

        public bool IsPaused { get; private set; }

        public bool IsCompleted { get; private set; }

        public bool IsStopped { get; private set; }

        public bool IsDone => IsCompleted || IsStopped;

        public void Restart(float duration)
        {
            _startTime = GetWorldTime();
            Duration = duration;
            IsPaused = false;
            IsCompleted = false;
            IsStopped = false;
            _timerRunner.RegisterTimer(this);
        }

        public void Pause()
        {
            if (IsDone || IsPaused)
            {
                return;
            }

            IsPaused = true;
            Update();
        }

        public void Resume()
        {
            if (IsDone || !IsPaused)
            {
                return;
            }

            IsPaused = false;
            Update();
        }

        public void Stop()
        {
            if (IsDone)
            {
                return;
            }

            Pause();
            IsStopped = true;
        }

        public float GetTimeElapsed()
        {
            if (IsCompleted)
            {
                return Duration;
            }

            return GetWorldTime() - _startTime;
        }

        public float GetTimeRemaining() =>
            Duration - Value;

        private float GetWorldTime() =>
            UsesRealTime ? Time.realtimeSinceStartup : Time.time;

        private float GetDismissTime() =>
            _startTime + Duration;

        private float GetDeltaTime() =>
            GetWorldTime() - _lastUpdateTime;

        public void Update()
        {
            if (IsDone)
            {
                return;
            }
            
            if (IsPaused)
            {
                _startTime += GetDeltaTime();
                _lastUpdateTime = GetWorldTime();
                return;
            }
            
            _lastUpdateTime = GetWorldTime();

            if (_lastUpdateTime >= GetDismissTime())
            {
                if (IsLooped)
                {
                    _startTime = _lastUpdateTime;
                }
                else
                {
                    IsCompleted = true;
                }

                Value = GetTimeElapsed();
                Completed?.Invoke();
            }
            else
            {
                Value = GetTimeElapsed();
            }
        }
    }
}