namespace DependencyInjection
{
    using Answer;
    using Audio;
    using Currency;
    using Infrastructure;
    using Question;
    using Reflex.Core;
    using Topic;
    using UnityEngine;
    using UnityEngine.Audio;

    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private float _secondsBetweenHealthRecovery;
        [SerializeField] private AudioMixer _audioMixer;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            Health health = new();
            Music music = new();
            Sound sound = new();

            containerBuilder
                .AddSingleton(new ServicesProvider())
                .AddSingleton(new Topic())
                .AddSingleton(music)
                .AddSingleton(sound)
                .AddSingleton(new AudioMixerController(_audioMixer, music, sound))
                .AddSingleton(new AnswerDataList())
                .AddSingleton(new QuestionDataList())
                .AddSingleton(new Money())
                .AddSingleton(health)
                .AddSingleton(new Cup())
                .AddSingleton(new HealthRestorer(health, _secondsBetweenHealthRecovery));
        }
    }
}