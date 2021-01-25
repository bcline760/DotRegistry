using System;

using Autofac;
using DotRegistry.Interface.Service;

namespace DotRegistry.Service
{
    public class IocRegistration : Module
    {
        public IocRegistration()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GitHubService>().As<IGitHubService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
