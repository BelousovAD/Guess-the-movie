namespace Topic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Topic
    {
        private List<TopicType> _types = Enum.GetValues(typeof(TopicType)).Cast<TopicType>().ToList();
        private int _index;

        public TopicType Current => _types[_index];

        public void MoveNext() =>
            _index = ++_index % _types.Count;

        public void MovePrevious() =>
            _index = (--_index + _types.Count) % _types.Count;
    }
}
