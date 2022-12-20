using Lamazon.ViewModels.Enums;

namespace Lamazon.ViewModels.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public UserViewModel User { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }

        public List<OrderLineItemViewModel> OrderLineItems { get; set; }
    }
}
