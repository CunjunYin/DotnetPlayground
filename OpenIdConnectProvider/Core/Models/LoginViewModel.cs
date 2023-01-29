using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OpenIdConnectProvider.Core.Models
{
    public class LoginViewModel: IValidatableObject
    {
        [Required(ErrorMessage = "Email is required")]
        [FromForm(Name = "Username")]
        public string Username { get; set; }


        [FromForm(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if( string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("Invalid Username or Password");
            }
        }
    }
}