using System.ComponentModel.DataAnnotations;

namespace IdentityGuard.Data.DTO.Login
{
    public class LoginUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
