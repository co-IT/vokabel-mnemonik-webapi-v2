using System.Collections.Generic;
using Autofac;
using AutoMapper;
using VokabelMnemonikApi.Hypermedia.Mapper;

namespace VokabelMnemonikApi
{
    public class AutoMapperProfileRegistrationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => t.IsAssignableTo<Profile>())
                .As<Profile>()
                .SingleInstance();

            builder.Register(context => new MapperConfiguration(cfg =>
                {
                    var profiles = context.Resolve<IEnumerable<Profile>>();

                    foreach (var profile in profiles)
                        cfg.AddProfile(profile);
                }))
                .AsSelf()
                .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}