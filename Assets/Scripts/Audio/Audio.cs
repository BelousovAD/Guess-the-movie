namespace Audio
{
    using System;
    using UnityEngine;

    public class Audio
    {
        private bool _isEnabled = true;
        private float _volume = 1f;

        public event Action ActivityChanged;
        public event Action VolumeChanged;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            private set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    ActivityChanged?.Invoke();
                }
            }
        }

        public float Volume
        {
            get
            {
                return _volume;
            }

            private set
            {
                if (Mathf.Approximately(value, _volume) == false)
                {
                    _volume = value;
                    VolumeChanged?.Invoke();
                }
            }
        }

        public void Enable() =>
            IsEnabled = true;

        public void Disable() =>
            IsEnabled = false;

        public void SetVolume(float value) =>
            Volume = Mathf.Clamp01(value);
    }
}