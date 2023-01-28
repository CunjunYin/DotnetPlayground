using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenIdConnect.Core;
using OpenIdConnectProvider.Core.Types;

namespace OpenIdConnect.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {

        }

        [HttpGet(ResourceUris.V1.authentication)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<String> UserAuthentication(GetAuthenticationModel model) 
        {

            return "a";
        }
    }
}
