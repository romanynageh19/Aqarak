using System.ComponentModel.DataAnnotations;

namespace Aqarak.Dtos
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
