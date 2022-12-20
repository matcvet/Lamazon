using AutoMapper;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IRepository<ProductCategory> productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
            _productCategoryRepository.Add(productCategory);
        }

        public void DeleteProductCategoryById(int id)
        {
            _productCategoryRepository.DeleteById(id);
        }

        public List<ProductCategoryViewModel> GetAllProductCategories()
        {
            var productCategories = _productCategoryRepository.GetAll();
            return _mapper.Map<List<ProductCategoryViewModel>>(productCategories);
        }

        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            var productCategory = _productCategoryRepository.GetById(id);
            return _mapper.Map<ProductCategoryViewModel>(productCategory);
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
            _productCategoryRepository.Update(productCategory);
        }
    }
}
