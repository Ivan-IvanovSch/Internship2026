using System.ComponentModel.DataAnnotations;

namespace Internship.Models.DTOs
{
    public class CreateAccountDTO
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Username {  get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
