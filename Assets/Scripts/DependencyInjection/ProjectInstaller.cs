namespace DependencyInjection
{
    using Audio;
    using Reflex.Core;
    using Topic;
    using UnityEngine;

    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .AddSingleton(new Topic())
                .AddSingleton(new Music())
                .AddSingleton(new Sound());
        }
    }
}