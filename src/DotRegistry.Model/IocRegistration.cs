using System;

using Autofac;
using AutoMapper;
using MongoDB.Driver;

using DotRegistry.Contract.Provider;
using DotRegistry.Core;
using DotRegistry.Interface.Repository;
using DotRegistry.Model.Provider;
using DotRegistry.Model.Repository;
using DotRegistry.Model.GitHub;
using DotRegistry.Contract;

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
                      cfg.CreateMap<ProviderEntity, ProviderModel>().ReverseMap();
                      cfg.CreateMap<UserProfileEntity, UserProfileModel>().ReverseMap();
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

            builder.RegisterType<GitHubApiRepository>()
                .As<IGitHubApiRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProviderRepository>()
                .As<IProviderRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
