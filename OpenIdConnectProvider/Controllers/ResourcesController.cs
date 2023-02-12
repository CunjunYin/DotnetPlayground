using Microsoft.AspNetCore.Mvc;
using OpenIdConnectProvider.Core;
using OpenIdConnectProvider.Core.Models;

namespace OpenIdConnectProvider.Controllers
{
    public class ResourcesController : Controller
    {
        public ResourcesController()
        {

        }

        [HttpGet(ResourceUris.V1.getResourcesName)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<String> getResourcesName([FromHeader] ResourcesModel model)
        {
            // Validate model

            // Query reqources
            return "a";
        }
    }
}
