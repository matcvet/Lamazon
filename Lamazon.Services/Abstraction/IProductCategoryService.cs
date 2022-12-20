using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Abstraction
{
    public interface IProductCategoryService
    {
        List<ProductCategoryViewModel> GetAllProductCategories();
        ProductCategoryViewModel GetProductCategoryById(int id);
        void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void DeleteProductCategoryById(int id);
    }
}
