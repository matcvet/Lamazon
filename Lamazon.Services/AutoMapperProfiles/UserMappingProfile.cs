using Lamazon.DomainModels.Entities;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
