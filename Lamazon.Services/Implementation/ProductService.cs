using AutoMapper;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void CreateProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _productRepository.Add(product);
        }

        public void DeleteProductById(int id)
        {
            _productRepository.DeleteById(id);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(product);
        }

        public void UpdateProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _productRepository.Update(product);
        }
    }
}
