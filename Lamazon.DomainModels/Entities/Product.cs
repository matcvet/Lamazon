namespace Lamazon.DomainModels.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}
