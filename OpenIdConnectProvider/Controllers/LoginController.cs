using Microsoft.AspNetCore.Mvc;
using OpenIdConnect.Core;
using OpenIdConnectProvider.Models;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Types;

namespace OpenIdConnectProvider.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {

        }

        [HttpGet(ResourceUris.V1.login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ContentResult Login(string callback)
        {
            if(string.IsNullOrEmpty(callback))
            {
                return new ContentResult()
                {
                    Content = "",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            return base.Content(this.LoginHTML(callback), "text/html");
        }

        [HttpPost(ResourceUris.V1.login)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginViewModel model, string callback)
        {
            if (ModelState.IsValid)
            {
                var errorMessage = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
                var errorResponse = new ErrorResponse
                {
                    Error = ErrorResponseType.InvalidRequest,
                    ErrorDescription = errorMessage
                };

                return BadRequest(errorResponse.GenerateJsonErrorRespose());
            }

            if(string.IsNullOrEmpty(callback))
            {
                return BadRequest();
            }

            return Redirect(callback);
        }

        protected string LoginHTML(string redirectUri)
        {
            var html = System.IO.File.ReadAllText(@"./wwwroot/login.html");
            html = html.Replace("{{redirectUri}}", redirectUri);
            return html;
        }
    }
}
