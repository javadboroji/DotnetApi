using DotnetApi.Models;
namespace DotnetApi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);

        Product CreateProduct(Product product);
        Product? UpdateProduct(DotnetApi.models.UpdateProductDto dto);

        void DeleteProduct(int id);

    }
}
