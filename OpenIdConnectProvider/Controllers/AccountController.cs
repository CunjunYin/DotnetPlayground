using Microsoft.AspNetCore.Mvc;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Models;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Types;
using OpenIdConnectProvider.Core.Services;

namespace OpenIdConnectProvider.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        [HttpGet(ResourceUris.V1.login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ContentResult Login(AuthorizationCode model)
        {
            // https://localhost:7232/api/v1/login?audience=https://localhost:7232&client_id=saodfo&response_type=code&scope=user:name&redirect_uri=https://google.com.au&nonce=1
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                var errorResponse = new ErrorResponse
                {
                    Error = ErrorResponseType.invalid_request,
                    ErrorDescription = errorMessage
                };

                return new ContentResult()
                {
                    Content = errorMessage,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            return base.Content(this.LoginHTML(model.toString()), "text/html");
        }

        [HttpPost(ResourceUris.V1.login)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromForm]LoginViewModel user, [FromQuery]AuthorizationCode oAuth)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                var errorResponse = new ErrorResponse
                {
                    Error = ErrorResponseType.invalid_request,
                    ErrorDescription = errorMessage
                };

                return BadRequest(errorResponse.GenerateJsonErrorRespose());
            }

            return Redirect(String.Format(
                "{0}?code={1}&state={2}",
                oAuth.redirect_uri,
                new AuthenticationCode(
                    oAuth.client_id,
                    oAuth.redirect_uri,
                    "new",
                    oAuth.scope,
                    user.Username
                ).GenerateCode(),
                "state"
            ));
        }

        protected string LoginHTML(string redirectUri)
        {
            var html = System.IO.File.ReadAllText(@"./wwwroot/login.html");
            html = html.Replace("{{parms}}", redirectUri);
            return html;
        }
    }
}
