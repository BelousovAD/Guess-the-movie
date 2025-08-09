namespace Currency
{
    using System;
    using BelousovGameDev.ChangeableValue;
    using Extensions;

    public class Currency : ChangeableValue<int>
    {
        private const int MinValue = 0;

        private int _maxValue;

        public Currency(int maxValue = 0) =>
            SetMaxValue(maxValue);

        public event Action MaxValueChanged;

        public int MaxValue
        {
            get
            {
                return _maxValue;
            }

            private set
            {
                if (value != _maxValue)
                {
                    _maxValue = value;
                    MaxValueChanged?.Invoke();
                }
            }
        }

        public override int Value
        {
            get => base.Value;
            protected set => base.Value = value.Clamp(MinValue, MaxValue);
        }

        public void Earn(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            Value += amount;
        }

        public void SetMaxValue(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), "Can not be negative");
            }

            MaxValue = maxValue;
        }

        public bool TrySpend(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Can not be negative");
            }

            if (Value < amount)
            {
                return false;
            }
            
            Value -= amount;
            return true;
        }
    }
}