using System.Collections.Generic;

namespace VokabelMnemonikApi.Routing
{
    public interface IRouteRegistry
    {
        IEnumerable<RouteRegistration> Routes();
    }
}