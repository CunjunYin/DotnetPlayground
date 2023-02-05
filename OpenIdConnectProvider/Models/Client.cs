using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIdConnectProvider.Models;
public class Client
{
    public int Id { get; set; }
    public string GUID { get; set; }
    public string Name { get; set; }
    public string ClientID { get; set; }
    public string Scope { get; set; } = "name:read";
    public bool IsActive { get; set; }
    public string RedirectUris { get; set; } = "https://localhost:5000/";
}