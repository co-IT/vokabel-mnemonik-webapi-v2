using System;

namespace VokabelMnemonikApi.Hypermedia.Mapper
{
    internal class BaseUriResolver : IResolveBaseUri
    {
        public Uri Value => new Uri("http://localhost:3000/");
    }
}