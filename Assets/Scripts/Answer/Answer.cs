namespace Answer
{
    using System;
    using UnityEngine;

    public class Answer : MonoBehaviour
    {
        private AnswerData _data;

        public event Action DataChanged;

        public string LocalizationKey =>
            _data is not null ? _data.LocalizationKey : string.Empty;

        public void Initialize(AnswerData data)
        {
            _data = data;
            DataChanged?.Invoke();
        }
    }
}
