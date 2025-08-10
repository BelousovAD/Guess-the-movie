namespace Timer
{
    using System.Collections.Generic;
    using Common;

    public class TimerRunner : Singleton<TimerRunner>
    {
        private readonly List<Timer> _timers = new();
        private readonly List<Timer> _timersToAdd = new();

        private void Update()
        {
            if (_timersToAdd.Count > 0)
            {
                _timers.AddRange(_timersToAdd);
                _timersToAdd.Clear();
            }

            _timers.ForEach(timer => timer.Update());
            _timers.RemoveAll(timer => timer.IsDone);
        }

        public void RegisterTimer(Timer timer) =>
            _timersToAdd.Add(timer);

        public void PauseTimers() =>
            _timers.ForEach(timer => timer.Pause());

        public void ResumeAllTimers() =>
            _timers.ForEach(timer => timer.Resume());

        public void StopTimers()
        {
            _timers.ForEach(timer => timer.Stop());
            _timers.Clear();
            _timersToAdd.Clear();
        }
    }
}