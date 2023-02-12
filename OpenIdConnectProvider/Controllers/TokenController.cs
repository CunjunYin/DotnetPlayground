using Microsoft.AspNetCore.Mvc;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Models;
using OpenIdConnectProvider.Core.Services;
using OpenIdConnectProvider.Data.Repositories;

namespace OpenIdConnectProvider.Controllers
{
    public class TokenController : Controller
    {
        private DatabaseContext db;
        ICodeValidater codeValidater;
        public TokenController(DatabaseContext db, ICodeValidater codeValidater){
            this.db = db;
            this.codeValidater = codeValidater;
        }

        [HttpPost(ResourceUris.V1.requestAccessToken)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AccessTokenExchange([FromBody] CodeExchangeModel value)
        {
            // Validate the authorization request
            // validate the request is well-formed
            if(value == null) {
                return BadRequest();
            }

            // Validate all required parameters: client id, redirect URI, scope, and state.
            if (!codeValidater.isValid(value)) {
                return Unauthorized();
            }

            // Generate the access token: Creating a JSON Web Token (JWT) that includes the user's claims and
            // signing it with the server's private key. The access token include an expiration time and a scope
            // that defines the resources that the client is authorized to access.
            AccessTokenResponse response = new AccessTokenResponse {
                access_token = TokenProvider.accessToken("", "", value.audience, 300),
                refresh_token = TokenProvider.accessToken("", "", value.audience, 3000),
                expires_in = DateTime.UtcNow.AddSeconds(300).ToString(),
                id_token = TokenProvider.IdToken(db, value.code, 300), 
                token_type = "bearer",
            };

            return new ContentResult(){
                Content = response.GenerateJsonErrorRespose(),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<String> RefreshTokenExchange(string token)
        {
            return "a";
        }
    }
}
