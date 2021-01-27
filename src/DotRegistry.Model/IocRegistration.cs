using System;

using Autofac;

using AutoMapper;

using DotRegistry.Contract;
using DotRegistry.Contract.GitHub;
using DotRegistry.Contract.Provider;
using DotRegistry.Core;
using DotRegistry.Interface.Repository;
using DotRegistry.Model.GitHub;
using DotRegistry.Model.Provider;
using DotRegistry.Model.Repository;

using MongoDB.Driver;

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
                      cfg.CreateMap<UserProfileEntity, UserProfileModel>()
                        .ForMember(m => m.EmailAddress, m => m.MapFrom(mm => mm.Email))
                        .ReverseMap();
                      cfg.CreateMap<GitHubGpgKey, GpgSigningKeyModel>()
                        .ForMember(m => m.ArmoredPublicKey, m => m.MapFrom(mm => mm.GpgPublicKey))
                        .ReverseMap();
                  });

                var map = mapConfig.CreateMapper();

                return map;
            }).As<IMapper>().SingleInstance();

            builder.Register(r =>
            {
                var connectString = Environment.GetEnvironmentVariable(Constants.ConnectionStringEnvName);
                var dbName = Environment.GetEnvironmentVariable(Constants.DatabaseNameEnvName);
                if (string.IsNullOrEmpty(connectString))
                    throw new InvalidOperationException();

                var settings = MongoClientSettings.FromUrl(MongoUrl.Create(connectString));
                var client = new MongoClient(settings);
                IMongoDatabase db = client.GetDatabase(dbName);
                return db;
            }).As<IMongoDatabase>().SingleInstance();

            builder.RegisterType<GitHubApiRepository>()
                .As<IGitHubApiRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProviderRepository>()
                .As<IProviderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserProfileRepository>()
                .As<IUserProfileRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}