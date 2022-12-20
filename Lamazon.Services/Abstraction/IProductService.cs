using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Abstraction
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        void CreateProduct(ProductViewModel productViewModel);
        void UpdateProduct(ProductViewModel productViewModel);
        void DeleteProductById(int id);
    }
}
