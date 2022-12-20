using Lamazon.DomainModels.Entities;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class OrderMappingProfile : AutoMapper.Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
