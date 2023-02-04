using Microsoft.AspNetCore.Mvc;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Models;

namespace OpenIdConnectProvider.Controllers
{
    public class TokenController : Controller
    {

        [HttpPost(ResourceUris.V1.requestAccessToken)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AccessTokenExchange(AccessTokenExchangeModel value)
        {
            // validate AccessTokenExchangeModel
            if(value == null) {
                return BadRequest();
            }

            AccessTokenResponse response = new AccessTokenResponse{
                access_token = "",
                refresh_token =  "",
                expires_in = "",
                id_token = "", 
                token_type = "",
            };

            return new ContentResult(){
                Content = response.GenerateJsonErrorRespose(),
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        public async Task<String> RefreshTokenExchange(string token)
        {
            return "a";
        }
    }
}
