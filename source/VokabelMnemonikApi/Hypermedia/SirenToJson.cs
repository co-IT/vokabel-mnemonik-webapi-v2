using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SirenDotNet;
using VokabelMnemonikApi.Hypermedia.Mapper;

namespace VokabelMnemonikApi.Hypermedia
{
    public class SirenToJson<T> : ISerializeHyperMedia<T, Entity> where T : class, new()
    {
        public SirenToJson(IMapEntitiesToHyperMedia<T, Entity> mapper)
        {
            Mapper = mapper;
        }

        public IMapEntitiesToHyperMedia<T, Entity> Mapper { get; }

        public MediaTypeFormatter Formatter => new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }
        };

        public MediaTypeHeaderValue MediaTypeHeaderValue => new MediaTypeHeaderValue("application/vnd.siren+json");
    }
}