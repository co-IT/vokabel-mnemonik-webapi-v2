using Autofac;

namespace VokabelMnemonikApi.Hypermedia.Mapper
{
    public class FormatterRegistrationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .AsClosedTypesOf(typeof(IMapEntitiesToHyperMedia<,>))
                .SingleInstance();

            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .AsClosedTypesOf(typeof(ISerializeHyperMedia<,>))
                .SingleInstance();
        }
    }
}