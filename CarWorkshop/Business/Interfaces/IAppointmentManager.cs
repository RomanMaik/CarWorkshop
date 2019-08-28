
using Models;
using Models.Dto;
using System;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IAppointmentManager
    {
        StatusDto AddAppointment(Appointment model);
        void DeleteAppointment(Appointment model);
        Appointment ChangeAppointmentDate(string userName, string companyName, DateTime newDate);
        List<Appointment> GetAll();
    }
}
