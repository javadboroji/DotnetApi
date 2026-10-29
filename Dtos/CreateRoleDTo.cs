using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Dtos
{
    public class CreateRoleDTo
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }=string.Empty;
    }
}
