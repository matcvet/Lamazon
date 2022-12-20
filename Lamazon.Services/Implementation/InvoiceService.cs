using AutoMapper;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository<Invoice> invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public void CreateInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceViewModel);
            _invoiceRepository.Add(invoice);
        }

        public void DeleteInvoiceById(int id)
        {
            _invoiceRepository.DeleteById(id);
        }

        public List<InvoiceViewModel> GetAllInvoices()
        {
            var invoices = _invoiceRepository.GetAll();
            return _mapper.Map<List<InvoiceViewModel>>(invoices);
        }

        public InvoiceViewModel GetInvoiceById(int id)
        {
            var invoice = _invoiceRepository.GetById(id);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }

        public void UpdateInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceViewModel);
            _invoiceRepository.Update(invoice);
        }
    }
}
