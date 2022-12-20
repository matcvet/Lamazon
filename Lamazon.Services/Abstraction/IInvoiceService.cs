using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Abstraction
{
    public interface IInvoiceService
    {
        List<InvoiceViewModel> GetAllInvoices();
        InvoiceViewModel GetInvoiceById(int id);
        void CreateInvoice(InvoiceViewModel invoiceViewModel);
        void UpdateInvoice(InvoiceViewModel invoiceViewModel);
        void DeleteInvoiceById(int id);
    }
}
