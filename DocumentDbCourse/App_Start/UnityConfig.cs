using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using DocumentDbCourse.Repository;
using DocumentDbCourse.Configuration;
using DocumentDbCourse.Models;

namespace DocumentDbCourse
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register this as a singleton.
            container.RegisterType<IRepositoryConfiguration, RepositoryConfiguration>(new ContainerControlledLifetimeManager());

            container.RegisterType<IConfigurationReader, ConfigurationReader>();
            container.RegisterType<INamedSettingResolver, NamedSettingResolver>();

            RegisterAllDbRepositories(container);
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


        private static void RegisterAllDbRepositories(UnityContainer container)
        {
            var repoConfig = container.Resolve<IRepositoryConfiguration>();
            foreach(var collectionId in repoConfig.CollectionIds)
            {
                container.RegisterType(typeof(IDocumentDbRepository<>), typeof(DocumentDbRepository<>), collectionId, new InjectionConstructor(collectionId, repoConfig));
            }
        }
     }
}