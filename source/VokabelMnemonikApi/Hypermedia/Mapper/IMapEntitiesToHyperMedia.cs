using System.Collections.Generic;

namespace VokabelMnemonikApi.Hypermedia.Mapper
{
    public interface IMapEntitiesToHyperMedia<in T, out THypermedia>
        where T : class, new()
    {
        THypermedia FromEntities(IEnumerable<T> genericEntities);
        THypermedia FromEntity(T entity);
    }
}