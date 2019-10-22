using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VersioningDemo.Controllers
{
    [Route("")]
    public class DefaultController : ApiController
    {
        [HttpOptions]
        public IHttpActionResult Options()
        {
            using var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty) };
            response.Content.Headers.Add("Allow", new[] { "GET", "POST", "OPTIONS" });
            response.Content.Headers.ContentType = null;
            return ResponseMessage(response);
        }

    }
}
