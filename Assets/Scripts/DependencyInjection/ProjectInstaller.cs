namespace DependencyInjection
{
    using Reflex.Core;
    using Settings;
    using UnityEngine;

    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new GameSettings());
        }
    }
}