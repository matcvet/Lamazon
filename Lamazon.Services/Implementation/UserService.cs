using AutoMapper;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Lamazon.Exceptions;
using Lamazon.Services.Abstraction;
using Lamazon.Services.Helpers;
using Lamazon.ViewModels.Constants;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteById(id);
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel RegisterUser(UserViewModel userViewModel)
        {
            if (string.IsNullOrEmpty(userViewModel.Email))
            {
                throw new UserException(null, null, "A valid e-mail address is required!");
            }

            if (ValidateEmailAddress(userViewModel.Email))
            {
                throw new UserException(null, null, "E-mail address already in use!");
            }

            if (string.IsNullOrEmpty(userViewModel.Username))
            {
                throw new UserException(null, null, "Username is required!");
            }

            if (ValidateUserName(userViewModel.Username))
            {
                throw new UserException(null, null, "Username already exists!");
            }

            var user = _mapper.Map<User>(userViewModel);
            PasswordHashHelper.HashPassword(user, userViewModel.Password);
            user.RoleKey = Roles.User;
            _userRepository.Add(user);
            return GetUserById(user.Id);
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            _userRepository.Update(user);
        }

        public UserViewModel ValidateUser(UserCredentialsViewModel userCredentialsViewModel)
        {
            var user = _userRepository.GetByEmail(userCredentialsViewModel.Email);

            if (user == null)
            {
                throw new UserException(null, null, "Invalid email/password");
            }

            var passwordVerificationResult = PasswordHashHelper.VerifyHashedPassword(user, userCredentialsViewModel.Password);

            if (passwordVerificationResult == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                throw new UserException(null, null, "Invalid email/password");
            }

            return _mapper.Map<UserViewModel>(user);
        }

        public bool ValidateUserName(string userName)
        {
            return _userRepository.GetAll().Any(x => x.Username == userName);
        }

        public bool ValidateEmailAddress(string email) 
        {
            return _userRepository.GetAll().Any(x => x.Email == email);
        }
    }
}


