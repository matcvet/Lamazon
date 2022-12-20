namespace Lamazon.DomainModels.Entities
{
    public class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
