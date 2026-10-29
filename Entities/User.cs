using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public int FailedLoginAttempts { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int RoleId { get; set; }

    public Role Role { get; set; } = null;
}

