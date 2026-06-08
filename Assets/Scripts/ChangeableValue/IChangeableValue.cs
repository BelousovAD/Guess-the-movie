namespace ChangeableValue
{
    using System;

    public interface IChangeableValue
    {
        public event Action Changed;
    }
}