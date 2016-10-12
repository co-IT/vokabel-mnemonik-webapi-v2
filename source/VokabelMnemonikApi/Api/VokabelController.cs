using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace VokabelMnemonikApi.Api
{
    [Route("vokabeln")]
    public class VokabelController : ApiController
    {
        private readonly IVokabelnRepository _vokabeln;

        public VokabelController(IVokabelnRepository vokabeln)
        {
            _vokabeln = vokabeln;
        }

        public async Task<IHttpActionResult> GetAlle()
        {
            return await Task
                .FromResult(new ResponseMessageResult(
                        Request.CreateResponse(HttpStatusCode.OK,_vokabeln.Alle()))
                );
        }
    }
}