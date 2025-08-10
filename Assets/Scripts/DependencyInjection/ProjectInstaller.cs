namespace DependencyInjection
{
    using Answer;
    using Audio;
    using Currency;
    using Question;
    using Reflex.Core;
    using Timer;
    using Topic;
    using UnityEngine;

    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private TimerRunner _timerRunner;
        [SerializeField] private float _secondsBetweenHealthRecovery;
        [SerializeField] private int _maxHealth;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            Health health = new(_maxHealth);
            
            containerBuilder
                .AddSingleton(new Topic())
                .AddSingleton(new Music())
                .AddSingleton(new Sound())
                .AddSingleton(new AnswerDataList())
                .AddSingleton(new QuestionDataList())
                .AddSingleton(new Money())
                .AddSingleton(health)
                .AddSingleton(_timerRunner)
                .AddSingleton(new HealthRestorer(_timerRunner, health, _secondsBetweenHealthRecovery));
        }
    }
}