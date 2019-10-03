using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestServiceCore.Controllers
{
    [Route("")]
    public class DefaultController : ControllerBase
    {
        [HttpOptions]
        public IActionResult Options()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(string.Empty)};
            response.Content.Headers.Add("Allow", new[] { "GET", "POST", "OPTIONS" });
            response.Content.Headers.ContentType = null;
            return Ok(response);
        }

    }
}
