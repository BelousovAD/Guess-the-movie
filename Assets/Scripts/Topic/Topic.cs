namespace Topic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Topic
    {
        private readonly List<TopicType> _types = Enum.GetValues(typeof(TopicType)).Cast<TopicType>().ToList();
        private int _index;

        public event Action ValueChanged;

        private int Index
        {
            get
            {
                return _index;
            }
            
            set
            {
                if (value != _index)
                {
                    _index = value;
                    ValueChanged?.Invoke();
                }
            }
        }

        public TopicType Current => _types[Index];

        public void MoveNext() =>
            Index = (Index + 1) % _types.Count;

        public void MovePrevious() =>
            Index = (Index - 1 + _types.Count) % _types.Count;
    }
}
