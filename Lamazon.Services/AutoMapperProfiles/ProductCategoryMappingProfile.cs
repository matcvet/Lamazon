using Lamazon.DomainModels.Entities;
using Lamazon.Services.AutoMapperPropertyResolvers;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class ProductCategoryMappingProfile : AutoMapper.Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom<ProductCategoryNameResolver>())
                .ReverseMap();
        }
    }
}
