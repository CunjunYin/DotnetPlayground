namespace OpenIdConnectProvider.Core.Models;

public class Client 
{
    public string GUID { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public string ClientID { get; set; }

    public List<string> RedirectUris { get; set; }

    public List<string> Scope { get; set; }
    public ushort AllowedLifeTime { get; set; } = 300;
}
    
    