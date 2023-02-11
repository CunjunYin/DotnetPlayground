using Microsoft.AspNetCore.Mvc;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Models;
using OpenIdConnectProvider.Core.Types;
using OpenIdConnectProvider.Core.Services;
using OpenIdConnectProvider.Data.Repositories;
using OpenIdConnectProvider.Data.Models;

namespace OpenIdConnectProvider.Controllers
{
    public class AccountController : Controller
    {
        public readonly DatabaseContext db;
        public readonly IClientValidator clientValidator;
        public AccountController(DatabaseContext db, IClientValidator clientValidator)
        {
            this.db = db;
            this.clientValidator = clientValidator;
        }

        [HttpGet(ResourceUris.V1.login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ContentResult Login(AuthorizationCodeModel model)
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

            if (!clientValidator.isValid(model))
            {
                return new ContentResult()
                {
                    Content = "Invalid Client",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            return base.Content(this.LoginHTML(model.toString()), "text/html");
        }

        [HttpPost(ResourceUris.V1.login)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromForm] LoginViewModel user, [FromQuery] AuthorizationCodeModel oAuth)
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

            var GUID = db.Users.Where(u => u.Name == user.Username).FirstOrDefault();

            if (GUID == null)
            {
                return Unauthorized();
            }

            string code = new AuthorizationCodeService(
                oAuth.client_id,
                oAuth.redirect_uri,
                "new",
                oAuth.scope,
                user.Username
            ).GenerateCode();

            using (var transaction = db.Database.BeginTransaction())
            {
                db.Add<AuthenticationCode>(new AuthenticationCode
                {
                    Code = code,
                    Audience = oAuth.audience,
                    ClientId = oAuth.client_id,
                    ResponseType = oAuth.response_type,
                    Scope = oAuth.scope,
                    RedirectUri = oAuth.redirect_uri,
                    Nounce = oAuth.nonce,
                    Used = false,
                    UserId = GUID.Guid,
                    ExpiresIn = DateTime.UtcNow.AddSeconds(300),
                });
                db.SaveChanges();
                transaction.Commit();
            }

            return Redirect(String.Format(
                "{0}?code={1}&state={2}",
                oAuth.redirect_uri,
                code,
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
