using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace DotnetApi.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Role Role { get; set; } = null!;

        public Permission Permission { get; set; } = null!;

    }
}
