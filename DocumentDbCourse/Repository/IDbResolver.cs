using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentDbCourse.Repository
{
    public interface INamedSettingResolver
    {
       T Resolve<T>(string name);
    }

    public class NamedSettingResolver : INamedSettingResolver
    {
        private readonly IUnityContainer container;

        public NamedSettingResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>(string name)
        {
          return container.Resolve<T>(name);
        }
    }
}