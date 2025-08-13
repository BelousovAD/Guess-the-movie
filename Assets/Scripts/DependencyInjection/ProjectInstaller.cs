namespace DependencyInjection
{
    using Answer;
    using Audio;
    using Currency;
    using Question;
    using Reflex.Core;
    using Topic;
    using UnityEngine;

    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private float _secondsBetweenHealthRecovery;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            Health health = new();

            containerBuilder
                .AddSingleton(new Topic())
                .AddSingleton(new Music())
                .AddSingleton(new Sound())
                .AddSingleton(new AnswerDataList())
                .AddSingleton(new QuestionDataList())
                .AddSingleton(new Money())
                .AddSingleton(health)
                .AddSingleton(new Cup())
                .AddSingleton(new HealthRestorer(health, _secondsBetweenHealthRecovery));
        }
    }
}