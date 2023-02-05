using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIdConnectProvider.Models;
public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; }
    public string Audience { get; set; }
    public string ClientId { get; set; }
    public string ResponseType { get; set; }
    public string Scope { get; set; }
    public string RedirectUri { get; set; }
    public string UserId { get; set; }
    public bool Used { get; set; }
    public DateTime ExpiresIn { get; set; }
}