using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Abstraction
{
    public interface IRoleService
    {
        List<RoleViewModel> GetAllRoles();
        RoleViewModel GetRoleById(int id);
    }
}
