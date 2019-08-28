
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Dto;
using Models.Enum;

namespace DAL.Repositories
{
    public class CarworkshoRepository : IBaseRepository<CarWorkshop>
    {
        private DbContext _carWorkshopContext;

        public StatusDto Add(CarWorkshop model)
        {
            if (!_carWorkshopContext.Workshops.ContainsKey(model.CompanyName))
            {
                _carWorkshopContext.Workshops.Add(model.CompanyName, model);

                return new StatusDto { Message = "User successfully added", Status = ActionResult.Success };
            }

            return new StatusDto { Message = "Username already exist", Status = ActionResult.UniqueKeyError };
        }

        public void Delete(CarWorkshop model)
        {
            _carWorkshopContext.Workshops.Remove(model.CompanyName);
        }

        public CarWorkshop Get(Func<CarWorkshop, bool> predicate)
        {
            return _carWorkshopContext.Workshops.Select(p => p.Value).ToList().FirstOrDefault(predicate);
        }

        public List<CarWorkshop> GetAll()
        {
            return _carWorkshopContext.Workshops.Select(p => p.Value).ToList();
        }

        public void Update(CarWorkshop model)
        {
            if (!_carWorkshopContext.Workshops.ContainsKey(model.CompanyName))
            {
                _carWorkshopContext.Workshops[model.CompanyName] = model;
            }
        }
    }
}
