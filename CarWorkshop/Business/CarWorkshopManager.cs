using System.Collections.Generic;
using Business.Interfaces;
using DAL.Interfaces;
using Models;
using Models.Dto;

namespace Business
{
    public class CarWorkshopManager : ICarWorkshopManager
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarWorkshopManager(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }

        public StatusDto AddWorkshop(CarWorkshop model)
        {
            return _carWorkshopRepository.Add(model);
        }

        public void DeleteWorkshop(CarWorkshop model)
        {
            _carWorkshopRepository.Delete(model);
        }

        public List<CarWorkshop> GetAll()
        {
            return _carWorkshopRepository.GetAll();
        }

        public List<CarWorkshop> GetCarWorkshopsByCity(string cityName)
        {
            return _carWorkshopRepository.List(cr => cr.City == cityName);
        }
    }
}
