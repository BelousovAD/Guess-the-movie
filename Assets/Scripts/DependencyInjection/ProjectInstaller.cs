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
        [SerializeField] private int _maxHealth = 5;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .AddSingleton(new Topic())
                .AddSingleton(new Music())
                .AddSingleton(new Sound())
                .AddSingleton(new AnswerDataList())
                .AddSingleton(new QuestionDataList())
                .AddSingleton(new Money())
                .AddSingleton(new Health(_maxHealth));
        }
    }
}