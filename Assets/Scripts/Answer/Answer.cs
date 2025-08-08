namespace Answer
{
    using System;
    using UnityEngine;

    public class Answer : MonoBehaviour
    {
        private AnswerData _data;

        public event Action DataChanged;
        public event Action<Answer> Chosen;

        public string Id => _data is null ? string.Empty : _data.Id;

        public string LocalizationKey => _data is null ? string.Empty : _data.LocalizationKey;

        public void Initialize(AnswerData data)
        {
            _data = data;
            DataChanged?.Invoke();
        }

        public void Choose() =>
            Chosen?.Invoke(this);
    }
}
