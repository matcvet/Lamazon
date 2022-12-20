using Lamazon.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public ShoppingCartController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index(int id)
        {
            ViewBag.UserOrders = _orderService.GetAllOrdersByUserId(id);

            return View();
        }
    }
}
