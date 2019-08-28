using DAL.Interfaces;
using Models;
using Models.Dto;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private IDbContext _carWorkshopContext;

        public AppointmentRepository(IDbContext dbContext)
        {
            _carWorkshopContext = dbContext;
        }

        public StatusDto Add(Appointment model)
        {
            if (!_carWorkshopContext.Users.ContainsKey(model.UserName))
            {
                return new StatusDto { Message = "Invalid user name", Status = ActionResult.BadRequest };
            }

            if (!_carWorkshopContext.Workshops.ContainsKey(model.CompanyName))
            {
                return new StatusDto { Message = "Invalid company name", Status = ActionResult.BadRequest };
            }

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

        public List<Appointment> List(Func<Appointment, bool> predicate)
        {
            return _carWorkshopContext.Appointments.Select(p => p.Value).Where(predicate).ToList();
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
