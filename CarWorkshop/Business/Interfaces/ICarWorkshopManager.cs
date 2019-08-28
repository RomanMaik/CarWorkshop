using Models;
using Models.Dto;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface ICarWorkshopManager
    {
        StatusDto AddWorkshop(CarWorkshop model);
        void DeleteWorkshop(CarWorkshop model);
        List<CarWorkshop> GetCarWorkshopsByCity(string cityName);
        List<CarWorkshop> GetAll();
    }
}
