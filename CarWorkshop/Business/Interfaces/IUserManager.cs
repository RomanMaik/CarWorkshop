using Models;
using Models.Dto;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IUserManager
    {
        StatusDto AddUser(User model);
        void DeleteUser(User model);
        List<User> GetAllUsers();
    }
}
