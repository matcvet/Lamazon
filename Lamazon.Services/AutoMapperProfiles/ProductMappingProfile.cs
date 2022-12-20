using Lamazon.DomainModels.Entities;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class ProductMappingProfile : AutoMapper.Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Info, opt => opt.MapFrom(s => $"{s.Id.ToString("000")} - {s.Name} ({s.ProductCategory.Name})"))
                .ReverseMap();
        }
    }
}
