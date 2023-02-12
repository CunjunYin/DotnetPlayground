using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OpenIdConnectProvider.Core.Models;
public class AuthorizationHeaderModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var authorization = bindingContext.HttpContext.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(authorization))
        {
            return Task.CompletedTask;
        }
        var tokens = authorization.Split(" ");
        var model = new ResourcesModel
        {
            accessToken = tokens[1],
            idToken = tokens[2],
        };

        bindingContext.Result = ModelBindingResult.Success(model);
        return Task.CompletedTask;
    }
}