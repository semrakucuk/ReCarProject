using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id); 
        List<Car> GetOrByColor(int id);
        List<Car> GetOrByBrand(int id); 
        List<Car> GetByUnitPrice(decimal min, decimal max);

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

        List<CarDetailDto> GetCarDetail();
    }
}
