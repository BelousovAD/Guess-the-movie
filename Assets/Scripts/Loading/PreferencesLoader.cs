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
        private Audio _music;
        private Audio _sound;

        [Inject]
        private void Initialize(Music music, Sound sound, Health health, Money money, Cup cup)
        {
            _music = music;
            _sound = sound;
            
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

        private void Start()
        {
            // NOTE: Настройки музыки и звуков должны загружаться в Start или позже,
            // потому что они вызывают изменения в AudioMixer.
            // В документации сказано, что если произвести изменения в AudioMixer раньше,
            // то это приведёт к неопределённому поведению.
            _music.Load();
            _sound.Load();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}