﻿using Microsoft.AspNetCore.Mvc;
using OpenIdConnect.Core;

namespace OpenIdConnectProvider.Controllers
{
    public class ResourcesController : Controller
    {
        public ResourcesController()
        {

        }

        [HttpGet(ResourceUris.V1.requestResources)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<String> getResources()
        {

            return "a";
        }
    }
}