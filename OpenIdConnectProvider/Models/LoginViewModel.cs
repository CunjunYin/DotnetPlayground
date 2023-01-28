using System.ComponentModel.DataAnnotations;

namespace OpenIdConnectProvider.Models
{
    public class LoginViewModel: IValidatableObject
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid email address")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
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