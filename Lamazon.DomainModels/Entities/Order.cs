namespace Lamazon.DomainModels.Entities
{
    public class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderNumber { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
