using System.Collections.Generic;
using VokabelMnemonikApi.Api;

namespace VokabelMnemonikApi.Routing
{
    public class VokabelControllerRoutes : IRegisterRoutes
    {
        public IEnumerable<RouteRegistration> Routes()
        {
            yield return new RouteRegistration
            {
                Action = "GetAlle",
                Controller = nameof(VokabelController).Replace("Controller", string.Empty),
                Name = "AlleVokabeln",
                UriTemplate = "vokabeln"
            };
        }
    }
}