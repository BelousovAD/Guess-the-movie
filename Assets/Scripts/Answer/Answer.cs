namespace Answer
{
    using System;
    using UnityEngine;

    public class Answer : MonoBehaviour
    {
        private AnswerData _data;
        private bool _isVisible = true;

        public event Action DataChanged;
        public event Action<Answer> Chosen;
        public event Action VisibilityChanged;

        public string Id => _data is null ? string.Empty : _data.Id;

        public string LocalizationKey => _data is null ? string.Empty : _data.LocalizationKey;

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            private set
            {
                if (value != _isVisible)
                {
                    _isVisible = value;
                    VisibilityChanged?.Invoke();
                }
            }
        }

        public void Initialize(AnswerData data)
        {
            _data = data;
            DataChanged?.Invoke();
        }

        public void Choose() =>
            Chosen?.Invoke(this);

        public void Show() =>
            IsVisible = true;

        public void Hide() =>
            IsVisible = false;
    }
}
