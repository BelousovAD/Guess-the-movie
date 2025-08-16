namespace Advertisement
{
    using BelousovGameDev.UI.Button;
    using Currency;
    using Infrastructure;
    using Reflex.Attributes;
    using UnityEngine;

    public class AdEarnHealthButton : AbstractButton
    {
        [SerializeField, Min(0)] private int _amount = 1;
        
        private Health _health;
        private ServicesProvider _servicesProvider;

        [Inject]
        private void Initialize(ServicesProvider servicesProvider, Health health)
        {
            _servicesProvider = servicesProvider;
            _health = health;
        }

        public override void HandleClick() =>
            _servicesProvider.Mediation.ShowRewardedAd(TakeReward);

        private void TakeReward() =>
            _health.Earn(_amount);
    }
}