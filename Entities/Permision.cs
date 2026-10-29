using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Entities
{
    public class Permission
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
