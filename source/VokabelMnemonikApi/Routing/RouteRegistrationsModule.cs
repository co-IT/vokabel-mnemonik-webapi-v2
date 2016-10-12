using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace VokabelMnemonikApi.Routing
{
    public class RouteRegistrationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => typeof(IRegisterRoutes)
                    .IsAssignableFrom(t))
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            builder
                .RegisterType<RouteRegistry>()
                .As<IRouteRegistry>();
        }
    }
}