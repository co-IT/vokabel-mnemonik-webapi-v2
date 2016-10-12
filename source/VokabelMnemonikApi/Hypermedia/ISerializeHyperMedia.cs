using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using VokabelMnemonikApi.Hypermedia.Mapper;

namespace VokabelMnemonikApi.Hypermedia
{
    public interface ISerializeHyperMedia<in T, out THypermedia> where T : class, new()
    {
        IMapEntitiesToHyperMedia<T, THypermedia> Mapper { get; }
        MediaTypeFormatter Formatter { get; }
        MediaTypeHeaderValue MediaTypeHeaderValue { get; }
    }
}