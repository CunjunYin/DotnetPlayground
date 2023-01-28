using Microsoft.AspNetCore.Mvc;
using OpenIdConnect.Core;

namespace OpenIdConnectProvider.Controllers
{
    public class TokenController : Controller
    {
        public TokenController()
        {

        }

        [HttpPost(ResourceUris.V1.requestAccessToken)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<String> tokenExchange()
        {

            return "a";
        }
    }
}
