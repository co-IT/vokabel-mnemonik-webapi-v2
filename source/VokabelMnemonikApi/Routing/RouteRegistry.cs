using System.Collections.Generic;
using System.Linq;

namespace VokabelMnemonikApi.Routing
{
    internal class RouteRegistry : IRouteRegistry
    {
        readonly IEnumerable<IRegisterRoutes> _allRegisteredRoutes;

        public RouteRegistry(IEnumerable<IRegisterRoutes> allRegisteredRoutes)
        {
            _allRegisteredRoutes = allRegisteredRoutes;
        }

        public IEnumerable<RouteRegistration> Routes()
        {
            var result = new List<RouteRegistration>();
            _allRegisteredRoutes.ToList().ForEach(registeredRoutes => result.AddRange(registeredRoutes.Routes()));
            return result;
        }
    }
}