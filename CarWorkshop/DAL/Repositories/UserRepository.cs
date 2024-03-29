﻿using DAL.Interfaces;
using Models;
using Models.Dto;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDbContext _carWorkshopContext;

        public UserRepository(IDbContext dbContext)
        {
            _carWorkshopContext = dbContext;
        }

        public StatusDto Add(User model)
        {
            if (!_carWorkshopContext.Users.ContainsKey(model.UserName))
            {
                _carWorkshopContext.Users.Add(model.UserName, model);

                return new StatusDto { Message = "User successfully added", Status = ActionResult.Success };
            }

            return new StatusDto { Message = "Username already exist", Status = ActionResult.UniqueKeyError };
        }

        public void Delete(User model)
        {
            _carWorkshopContext.Users.Remove(model.UserName);
        }

        public User Get(Func<User, bool> predicate)
        {
            return _carWorkshopContext.Users.Select(x => x.Value).ToList().FirstOrDefault(predicate);
        }

        public List<User> GetAll()
        {
            return _carWorkshopContext.Users.Select(x => x.Value).ToList();
        }

        public List<User> List(Func<User, bool> predicate)
        {
            return _carWorkshopContext.Users.Select(x => x.Value).Where(predicate).ToList();
        }

        public void Update(User model)
        {
            if (!_carWorkshopContext.Users.ContainsKey(model.UserName))
            {
                _carWorkshopContext.Users[model.UserName] = model;
            }
        }
    }
}
