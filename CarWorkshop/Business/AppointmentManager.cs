using System;
using System.Collections.Generic;
using Business.Interfaces;
using DAL.Interfaces;
using Models;
using Models.Dto;

namespace Business
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public StatusDto AddAppointment(Appointment model)
        {
            return _appointmentRepository.Add(model);
        }

        public Appointment ChangeAppointmentDate(string userName, string companyName, DateTime newDate)
        {
            var appointment = _appointmentRepository.Get(app => app.UserName == userName && app.CompanyName == companyName);

            appointment.AppDate = newDate;
            _appointmentRepository.Update(appointment);

            return appointment;
        }

        public void DeleteAppointment(Appointment model)
        {
            _appointmentRepository.Delete(model);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }
    }
}
