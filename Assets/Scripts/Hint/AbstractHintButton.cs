namespace Hint
{
    using BelousovGameDev.UI.Button;
    using Currency;
    using Question;
    using Reflex.Attributes;
    using UnityEngine;

    public abstract class AbstractHintButton : AbstractButton
    {
        [SerializeField] private Question _question;
        [SerializeField, Min(0)] private int _price;

        public int Price => _price;
        
        protected Money Money { get; private set; }

        protected Question Question => _question;

        [Inject]
        private void Initialize(Money money) =>
            Money = money;
    }
}