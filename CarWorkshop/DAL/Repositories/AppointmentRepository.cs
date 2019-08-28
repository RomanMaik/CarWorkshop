using Models;
using Models.Dto;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class AppointmentRepository : IBaseRepository<Appointment>
    {
        private DbContext _carWorkshopContext;

        public StatusDto Add(Appointment model)
        {
            if (!_carWorkshopContext.Appointments.ContainsKey(GetAppoinmentKey(model)))
            {
                _carWorkshopContext.Appointments.Add(GetAppoinmentKey(model), model);

                return new StatusDto { Message = "Appointment successfully added", Status = ActionResult.Success };
            }

            return new StatusDto { Message = "Appointment already exist", Status = ActionResult.UniqueKeyError };
        }

        public void Delete(Appointment model)
        {
            _carWorkshopContext.Appointments.Remove(GetAppoinmentKey(model.CompanyName,model.UserName));
        }

        public Appointment Get(Func<Appointment, bool> predicate)
        {
            return _carWorkshopContext.Appointments.Select(p => p.Value).ToList().FirstOrDefault(predicate);
        }

        public List<Appointment> GetAll()
        {
            return _carWorkshopContext.Appointments.Select(p => p.Value).ToList();
        }

        public void Update(Appointment model)
        {
            if (!_carWorkshopContext.Appointments.ContainsKey(GetAppoinmentKey(model)))
            {
                _carWorkshopContext.Appointments[GetAppoinmentKey(model)] = model;
            }
        }

        private KeyValuePair<string, string> GetAppoinmentKey(Appointment model)
        {
            return new KeyValuePair<string, string>(model.CompanyName, model.UserName);
        }

        private KeyValuePair<string, string> GetAppoinmentKey(string companyName,string userName)
        {
            return new KeyValuePair<string, string>(companyName, userName);
        }
    }
}
