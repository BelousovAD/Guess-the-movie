namespace UI
{
    using Common;
    using System;
    using UnityEngine;

    public class Window : MonoBehaviour
    {
        [SerializeField] private ID _id;

        private bool _isVisible = false;
        private WindowManipulator _windowManipulator;

        public event Action VisibleChanged;

        public string Id =>
            _id.Value;

        public WindowManipulator WindowManipulator =>
            _windowManipulator;

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
                    VisibleChanged();
                }
            }
        }

        public void Initialize(WindowManipulator windowManipulator) =>
            _windowManipulator = windowManipulator;

        public void Hide() =>
            IsVisible = false;

        public void Show() =>
            IsVisible = true;
    }
}
