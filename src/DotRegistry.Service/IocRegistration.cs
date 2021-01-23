using System;

using Autofac;

namespace DotRegistry.Service
{
    public class IocRegistration : Module
    {
        public IocRegistration()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<>
            base.Load(builder);
        }
    }
}
