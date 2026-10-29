using Microsoft.AspNetCore.Mvc;
using DotnetApi.Models;
using DotnetApi.Services;
using DotnetApi.models;
using Microsoft.AspNetCore.Authorization;
namespace DotnetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    [Authorize(Roles="Admin")]
    public IActionResult GetProducts()
    {
        return Ok(_productService.GetProducts());

    }
    [HttpGet("{id}")]
    
    public IActionResult GetProduct(int id)
    {
       var productFound = _productService.GetProductById(id);
        if (productFound == null)
        {
            return NotFound();
        }
        return Ok(productFound);
    }
     
    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
        };
        var productCreated = _productService.CreateProduct(product);
        return CreatedAtAction(
         nameof(GetProduct),
         new { id = productCreated.Id },
         productCreated
     );
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto productDto)
    {
        var product = _productService.UpdateProduct(productDto);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var productFound = _productService.GetProductById(id);
        if (productFound == null)
        {
            return NotFound();
        }
        _productService.DeleteProduct(id);
        return NoContent();
    }
}
