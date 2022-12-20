using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lamazon.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            List<ProductCategoryViewModel> productCategories = _productCategoryService.GetAllProductCategories();
            ViewBag.Categories = productCategories;

            return View(products);
        }

        public IActionResult Create(int id)
        {
            var model = id > 0 ? _productService.GetProductById(id) : new ProductViewModel();

            var productCategories = _productCategoryService.GetAllProductCategories();
            ViewBag.ProductCategoryId = new SelectList(productCategories, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            _productService.CreateProduct(productViewModel);
            return RedirectToAction("Index");
        }
    }
}
