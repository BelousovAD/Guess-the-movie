namespace Currency
{
    using System;
    using ChangeableValue;
    using Extensions;
    using romanlee17.MirraGames;

    public class Currency : ChangeableValue<int>
    {
        private const int MinValue = 0;

        private readonly string _id;
        private int _maxValue;

        public Currency(string id) =>
            _id = id;

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
                    Save();
                }
            }
        }

        public override int Value
        {
            get
            {
                return base.Value;
            }
            
            protected set
            {
                base.Value = value.Clamp(MinValue, MaxValue);
                Save();
            }
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

        public bool Load()
        {
            int maxValue = MirraSDK.Prefs.GetInt(_id + nameof(MaxValue), -1);
            int value = MirraSDK.Prefs.GetInt(_id + nameof(Value), -1);

            if (maxValue != -1 && value != -1)
            {
                SetMaxValue(maxValue);
                Earn(value);
                return true;
            }

            return false;
        }

        private void Save()
        {
            MirraSDK.Prefs.SetInt(_id + nameof(MaxValue), MaxValue);
            MirraSDK.Prefs.SetInt(_id + nameof(Value), Value);
            MirraSDK.Prefs.Save();
        }
    }
}