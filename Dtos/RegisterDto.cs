using System.ComponentModel.DataAnnotations;
namespace DotnetApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)] 
        public string Password { get; set; } = string.Empty;
    }
}
