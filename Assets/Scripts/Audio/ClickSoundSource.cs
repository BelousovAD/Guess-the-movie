namespace Audio
{
    using UnityEngine;

    [RequireComponent(typeof(AudioSource))]
    public class ClickSoundSource : MonoBehaviour
    {
        private AudioSource _audioSource;
        
        public static ClickSoundSource Instance { get; private set; }

        private void Awake()
        {
            if (Instance is null)
            {
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _audioSource = GetComponent<AudioSource>();
        }

        public void Play() =>
            _audioSource.Play();
    }
}