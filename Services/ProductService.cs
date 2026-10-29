using DotnetApi.Data;
using DotnetApi.models;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Services;

public class ProductService : IProductService   
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    public List<Product>  GetProducts()
    {
        return  _context.Products.ToList();
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }
    public Product CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }
    public Product UpdateProduct(UpdateProductDto dto)
    {
      var productFind =_context.Products.FirstOrDefault(p => p.Id == dto.Id);
        if (productFind == null)
        {
            return null;
        }
        productFind.Name = dto.Name;
        productFind.Price = dto.Price;

        _context.SaveChanges();

        return productFind;
    }
    public void DeleteProduct(int id)
    {
        var productFind = _context.Products.FirstOrDefault(p => p.Id == id);
        if (productFind == null)
        {
            return;
        }
        _context.Products.Remove(productFind);
        _context.SaveChanges();
    }
}
