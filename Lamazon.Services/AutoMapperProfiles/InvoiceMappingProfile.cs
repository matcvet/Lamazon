using Lamazon.DomainModels.Entities;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class InvoiceMappingProfile : AutoMapper.Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
        }
    }
}
