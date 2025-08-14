namespace Audio
{
    using System;
    using romanlee17.MirraGames;
    using UnityEngine;

    public class Audio
    {
        private readonly string _id;
        private bool _isEnabled = true;
        private float _volume = 1f;

        public Audio(string id) =>
            _id = id;

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
                    Save();
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
                    Save();
                }
            }
        }

        public void Enable() =>
            IsEnabled = true;

        public void Disable() =>
            IsEnabled = false;

        public void SetVolume(float value) =>
            Volume = Mathf.Clamp01(value);
        
        public void Load()
        {
            IsEnabled = MirraSDK.Prefs.GetBool(_id + nameof(IsEnabled), true);
            SetVolume(MirraSDK.Prefs.GetFloat(_id + nameof(Volume), 1f));
        }

        private void Save()
        {
            MirraSDK.Prefs.SetBool(_id + nameof(IsEnabled), IsEnabled);
            MirraSDK.Prefs.SetFloat(_id + nameof(Volume), Volume);
            MirraSDK.Prefs.Save();
        }
    }
}