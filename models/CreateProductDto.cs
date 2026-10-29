using System.ComponentModel.DataAnnotations;

namespace DotnetApi.Models;
public class CreateProductDto
{
    [Required]
    [StringLength(100 ,MinimumLength =3)]
    public required string Name { get; set; }
    [Range(0.01,double.MaxValue)]
    public decimal Price { get; set; }
}