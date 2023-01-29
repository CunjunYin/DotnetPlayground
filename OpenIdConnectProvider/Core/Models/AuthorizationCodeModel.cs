using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OpenIdConnectProvider.Core.Models;

public class AuthorizationCode: IValidatableObject
{
    [FromQuery(Name = "audience")]
    public string audience { get; set; }

    [FromQuery(Name = "client_id")]
    public string client_id { get; set; }

    [FromQuery(Name = "response_type")]
    public string response_type { get; set; }

    [FromQuery(Name = "scope")]
    public string scope { get; set; }

    [FromQuery(Name = "redirect_uri")]
    public string redirect_uri { get; set; }

    [FromQuery(Name = "nonce")]
    public string nonce { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrWhiteSpace(audience)) {
            yield return new ValidationResult("Empty audience Uri");
        }

        if(string.IsNullOrWhiteSpace(client_id)) {
            yield return new ValidationResult("Empty client id Uri");
        }

        if(string.IsNullOrWhiteSpace(response_type)) {
            yield return new ValidationResult("Empty response type Uri");
        }

        if(string.IsNullOrWhiteSpace(scope)) {
            yield return new ValidationResult("Empty scope Uri");
        }

        if(string.IsNullOrWhiteSpace(redirect_uri)) {
            yield return new ValidationResult("Empty Redirect Uri");
        }

        if(string.IsNullOrWhiteSpace(nonce)) {
            yield return new ValidationResult("Empty nonce Uri");
        }
    }

    public string toString()
    {
        return  String.Format(
            "audience={0}&client_id={1}&response_type={2}&scope={3}&redirect_uri={4}&nonce={5}",
            audience, client_id, response_type, scope, redirect_uri, nonce
        );
    }
}