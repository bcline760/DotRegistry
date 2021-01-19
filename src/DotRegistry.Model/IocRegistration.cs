using System;

using Autofac;
using AutoMapper;
using MongoDB.Driver;

using DotRegistry.Contract;
using DotRegistry.Core;
using DotRegistry.Interface;
using DotRegistry.Model.Repository;

namespace DotRegistry.Model
{
    public class IocRegistration : Module
    {
        public IocRegistration()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(r =>
            {
                var mapConfig = new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<ProviderPackage, ProviderPackageModel>().ReverseMap();
                  });

                var map = mapConfig.CreateMapper();

                return map;
            }).As<IMapper>().SingleInstance();

            builder.Register(r =>
            {
                var connectString = Environment.GetEnvironmentVariable(Constants.ConnectionStringEnvName);
                if (string.IsNullOrEmpty(connectString))
                    throw new InvalidOperationException();

                var settings = MongoClientSettings.FromUrl(MongoUrl.Create(connectString));
                var client = new MongoClient(settings);
                IMongoDatabase db = client.GetDatabase(connectString);
                return db;
            }).As<IMongoDatabase>().SingleInstance();

            builder.RegisterType<ProviderPackageRepository>()
                .As<IProviderPackageRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
