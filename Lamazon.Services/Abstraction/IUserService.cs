using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Abstraction
{
    public interface IUserService
    {
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUserById(int id);
        UserViewModel RegisterUser(UserViewModel userViewModel);
        void UpdateUser(UserViewModel userViewModel);
        void DeleteUserById(int id);
        UserViewModel ValidateUser(UserCredentialsViewModel userCredentialsViewModel);
        bool ValidateUserName(string userName);
        bool ValidateEmailAddress(string email);
    }
}
