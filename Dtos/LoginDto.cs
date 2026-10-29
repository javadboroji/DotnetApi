using System.ComponentModel.DataAnnotations;
namespace DotnetApi.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
