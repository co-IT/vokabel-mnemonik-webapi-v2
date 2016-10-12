using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Owin;
using SirenDotNet;
using VokabelMnemonikApi.Api;
using VokabelMnemonikApi.Hypermedia;
using VokabelMnemonikApi.Hypermedia.Mapper;
using VokabelMnemonikApi.Routing;

namespace VokabelMnemonikApi
{
    public class Startup
    {
        private IContainer _container;

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var builder = new ContainerBuilder();

            var thisAssembly = GetType().Assembly;
            builder.RegisterApiControllers(thisAssembly);
            builder.RegisterAssemblyModules(thisAssembly);
            builder.RegisterType<VokabelnRepository>().As<IVokabelnRepository>();
            builder.RegisterType<BaseUriResolver>().As<IResolveBaseUri>();

            _container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
            app.UseAutofacWebApi(config);
            app.UseAutofacMiddleware(_container);


            var formatters = new List<MediaTypeFormatter>();
            var routeRegistry = _container.Resolve<IRouteRegistry>();
            var baseUriResolver = _container.Resolve<IResolveBaseUri>();
            var automapper = _container.Resolve<IMapper>();

            formatters.Add(
                new GenericFormatter<Vokabel, Entity>(
                    new SirenToJson<Vokabel>(
                        new SirenVokabelMapper<Vokabel>(routeRegistry, baseUriResolver, automapper)
                    )
                )
            );

            foreach (var formatter in formatters)
                config.Formatters.Add(formatter);


            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
            app.UseWebApi(config);
        }

    }
}