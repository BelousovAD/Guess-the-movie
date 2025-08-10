namespace Timer
{
    using System.Collections.Generic;
    using UnityEngine;

    public class TimerRunner : MonoBehaviour
    {
        private readonly List<Timer> _timers = new();
        private readonly List<Timer> _timersToAdd = new();

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
    }
}