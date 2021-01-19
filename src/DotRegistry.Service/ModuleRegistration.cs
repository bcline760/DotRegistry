using System;

using DotRegistry.Interface;
using DotRegistry.Model;

using Autofac;

namespace DotRegistry.Service
{
    public static class ModuleRegistration
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new Model.IocRegistration());
            builder.RegisterModule(new IocRegistration());
        }
    }
}
