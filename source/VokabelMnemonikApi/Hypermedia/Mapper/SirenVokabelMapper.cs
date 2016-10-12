using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Linq;
using SirenDotNet;
using VokabelMnemonikApi.Api;
using VokabelMnemonikApi.Routing;

namespace VokabelMnemonikApi.Hypermedia.Mapper
{
    public class SirenVokabelMapper<T> : IMapEntitiesToHyperMedia<T, Entity> where T : class, new()
    {
        private readonly IMapper _automapper;
        private readonly IResolveBaseUri _baseUri;
        private readonly IRouteRegistry _routeRegistry;

        public SirenVokabelMapper(IRouteRegistry routeRegistry, IResolveBaseUri baseUri, IMapper automapper)
        {
            _routeRegistry = routeRegistry;
            _baseUri = baseUri;
            _automapper = automapper;
        }

        public Entity FromEntities(IEnumerable<T> genericEntities)
        {
            //Übergangslösung
            var entities = genericEntities as IEnumerable<Vokabel>;
            if (entities == null)
                return new Entity();

            return _automapper.Map<IEnumerable<Vokabel>, Entity>(entities);

            //var template = _routeRegistry.Routes().Single(r => r.Name == "AlleVokabeln").UriTemplate;
            //var selfLink = new Uri(_baseUri.Value, new UriTemplate(template).Resolve());

            //var subEntities = entities.ToList().Select(v =>
            //{
            //    var subEntity = new SubEntity.Embedded();
            //    subEntity.Properties = new JObject();
            //    subEntity.Properties.Add("Fremdwort", v.Fremdwort);
            //    subEntity.Properties.Add("Übersetzung", v.Übersetzung);
            //    return subEntity;
            //});
            //var result = new Entity
            //{
            //    Title = "Vokabeln",
            //    Links = new[] {new Link(selfLink)},
            //    Entities = subEntities
            //};

            //return result;
        }

        public Entity FromEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }

    public class Foobar : Profile
    {
        public Foobar(IRouteRegistry routeRegistry)
        {
            CreateMap<IEnumerable<Vokabel>, Entity>()
                //.ForMember(entity => entity.Title,
                //    mapper => { mapper.MapFrom(vokabeln => vokabeln.GetType().GenericTypeArguments[0].Name + 'n'); })
                .ForMember(entity => entity.Class,
                    mapper =>
                    {
                        mapper.MapFrom(vokabeln => new List<string> {vokabeln.GetType().GenericTypeArguments[0].Name});
                    })
                .ForMember(entity => entity.Properties,
                    mapper =>
                    {
                        mapper.ResolveUsing(vokabeln =>
                        {
                            var result = new JArray();
                            var jobj = new JObject();
                            var jprop = new JProperty("Anzahl", 10);
                            jobj.Add(jprop);
                            result.Add(jobj);
                            //result.Add(new JArray() { "Test" } );
                            //result.Add("Anzahl", vokabeln.Count());
                            return result;
                            //return "hello";
                        });
                    });
        }
    }


    public class Foobar2 : Profile
    {
        public Foobar2()
        {
            CreateMap<Vokabel, Entity>()
                .ForMember(entity => entity.Title, mapper => { mapper.MapFrom(vokabel => vokabel.GetType().Name); });
        }
    }
}