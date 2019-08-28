using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dto;

namespace CarWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Appointment> GetAllUsers()
        {
            return _appointmentManager.GetAll();
        }

        [HttpPost]
        [Route("AddAppointment")]
        public string AddUser(Appointment model)
        {
            return _appointmentManager.AddAppointment(model).Message;
        }

        [HttpPost]
        [Route("DeleteAppointment")]
        public void DeleteUser(Appointment model)
        {
            _appointmentManager.DeleteAppointment(model);
        }
    }
}