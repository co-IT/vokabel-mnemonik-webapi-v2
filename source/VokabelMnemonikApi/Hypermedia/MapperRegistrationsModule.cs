using System;
using Autofac;
using VokabelMnemonikApi.Hypermedia.Mapper;

namespace VokabelMnemonikApi.Hypermedia
{
    public class MapperRegistrationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .AsClosedTypesOf(typeof(IMapEntitiesToHyperMedia<,>))
                .WithMetadata("key", ServiceNameMapping)
                .Named(ServiceNameMapping, typeof(IMapEntitiesToHyperMedia<,>))
                .SingleInstance();
        }

        private static string ServiceNameMapping(Type type)
        {
            var name = type.Name.ToLower();
            return name;
        }
    }
}