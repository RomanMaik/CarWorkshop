using System.Collections.Generic;
using Business.Interfaces;
using DAL.Interfaces;
using Models;
using Models.Dto;

namespace Business
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public StatusDto AddUser(User model)
        {
            return _userRepository.Add(model);
        }

        public void DeleteUser(User model)
        {
            _userRepository.Delete(model);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
