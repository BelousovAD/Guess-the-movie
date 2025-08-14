namespace Advertisement
{
    using Currency;
    using Reflex.Attributes;
    using Savvy.Infrastructure;
    using Savvy.Services.Mediation;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class AdEarnHealthButton : MonoSavvy
    {
        [SerializeField, Min(0)] private int _amount = 1;
        
        private IMediationService _mediation;
        private Button _button;
        private Health _health;

        [Inject]
        private void Initialize(Health health) =>
            _health = health;

        private void Awake()
        {
            _mediation = GetService<IMediationService>();
            _button = GetComponent<Button>();
        }

        private void OnEnable() =>
            _button.onClick.AddListener(HandleClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(HandleClick);

        private void HandleClick() =>
            _mediation.ShowRewardedAd(TakeReward);

        private void TakeReward() =>
            _health.Earn(_amount);
    }
}