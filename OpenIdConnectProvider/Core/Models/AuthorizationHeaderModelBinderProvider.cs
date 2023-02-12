using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpenIdConnectProvider.Core.Models;

public class AuthorizationHeaderModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(ResourcesModel))
        {
            return new AuthorizationHeaderModelBinder();
        }

        return null;
    }
}