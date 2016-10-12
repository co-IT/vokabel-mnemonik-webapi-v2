using System.Collections.Generic;

namespace VokabelMnemonikApi.Routing
{
    public interface IRegisterRoutes
    {
        IEnumerable<RouteRegistration> Routes();
    }
}