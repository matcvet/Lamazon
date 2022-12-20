using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Abstraction
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        List<OrderViewModel> GetAllOrdersByUserId(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void UpdateOrder(OrderViewModel orderViewModel);
        void DeleteOrderById(int id);
    }
}
