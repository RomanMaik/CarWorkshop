using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dto;

namespace CarWorkshopMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<User> GetAllUsers()
        {
            return _userManager.GetAllUsers();
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser(User model)
        {
            return _userManager.AddUser(model).Message;
        }

        [HttpPost]
        [Route("DeleteUser")]
        public void DeleteUser(User model)
        {
            _userManager.DeleteUser(model);
        }
    }
}
