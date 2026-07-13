using System.ComponentModel.DataAnnotations;

namespace Internship.Models.DTOs
{
    public class LogInAccountDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
