using System.ComponentModel.DataAnnotations;

namespace OpenIdPG.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Useranme { get; set; }

        [Required]
        [StringLength(1000)]
        public string Password { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Email> Emails { get; set; } = new List<Email>();
    }
}
                                                                                                