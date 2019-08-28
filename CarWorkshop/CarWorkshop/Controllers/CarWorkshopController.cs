using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models;

namespace CarWorkshopMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarWorkshopController : ControllerBase
    {
        private readonly ICarWorkshopManager _carWorkshopManager;

        public CarWorkshopController(ICarWorkshopManager carWorkshopManager)
        {
            _carWorkshopManager = carWorkshopManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Models.CarWorkshop> GetAllUsers()
        {
            return _carWorkshopManager.GetAll();
        }

        [HttpGet]
        [Route("GetByCityName")]
        public List<Models.CarWorkshop> GetCarWorkshopsByCityName(string cityName)
        {
            return _carWorkshopManager.GetCarWorkshopsByCity(cityName);
        }


        [HttpPost]
        [Route("AddCarWorkshop")]
        public string AddUser(Models.CarWorkshop model)
        {
            return _carWorkshopManager.AddWorkshop(model).Message;
        }

        [HttpPost]
        [Route("DeleteCarWorkshop")]
        public void DeleteUser(Models.CarWorkshop model)
        {
            _carWorkshopManager.DeleteWorkshop(model);
        }
    }
}