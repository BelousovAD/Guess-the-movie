namespace Answer
{
    using System;
    using UnityEngine;

    public class Answer : MonoBehaviour
    {
        private AnswerData _data;

        public event Action DataChanged;

        public string LocalizationKey =>
            _data.LocalizationKey;

        public void Initialize(AnswerData data)
        {
            _data = data;
            DataChanged?.Invoke();
        }
    }
}
