using AutoMapper;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            var roles = _roleRepository.GetAll();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public RoleViewModel GetRoleById(int id)
        {
            var role = _roleRepository.GetById(id);
            return _mapper.Map<RoleViewModel>(role);
        }
    }
}
