namespace Loading
{
    using Audio;
    using Currency;
    using Reflex.Attributes;
    using romanlee17.MirraGames;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PreferencesLoader : MonoBehaviour
    {
        private const string FirstTimeKey = nameof(FirstTimeKey);

        [SerializeField, Min(0)] private int _maxHealth = 5;

        [Inject]
        private void Initialize(Music music, Sound sound, Health health, Money money, Cup cup)
        {
            music.Load();
            sound.Load();
            
            if (money.Load() == false)
            {
                money.SetMaxValue(int.MaxValue);
            }

            if (health.Load() == false)
            {
                health.SetMaxValue(_maxHealth);
            }

            if (cup.Load() == false)
            {
                cup.SetMaxValue(int.MaxValue);
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