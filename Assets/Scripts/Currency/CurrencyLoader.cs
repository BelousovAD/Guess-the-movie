namespace Currency
{
    using Reflex.Attributes;
    using romanlee17.MirraGames;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class CurrencyLoader : MonoBehaviour
    {
        private const string FirstTimeKey = nameof(FirstTimeKey);

        [SerializeField, Min(0)] private int _maxHealth = 5;

        [Inject]
        private void Initialize(Health health, Money money)
        {
            if (money.Load() == false)
            {
                money.SetMaxValue(int.MaxValue);
            }

            if (health.Load() == false)
            {
                health.SetMaxValue(_maxHealth);
            }
            
            if (MirraSDK.Prefs.GetBool(FirstTimeKey) == false)
            {
                health.Earn(health.MaxValue);
                MirraSDK.Prefs.SetBool(FirstTimeKey, true);
            }
        }

        private void Start() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}