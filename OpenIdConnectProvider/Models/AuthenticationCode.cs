using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIdConnectProvider.Models;
public class AuthenticationCode
{
    public int Id { get; set; }

    [Required]
    public string ClientID { get; set; }
}

