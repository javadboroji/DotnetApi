using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace DotnetApi.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public bool IsActive { get; set; }=true;

        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;

        [JsonIgnore]
        public ICollection<User> Users { get; set; }=new List<User>();

        [JsonIgnore]
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
