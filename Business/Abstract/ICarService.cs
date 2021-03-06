using Core;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult< Car> GetById(int id);
        IDataResult<List<Car>> GetOrByColor(int id);
        IDataResult<List<Car>> GetOrByBrand(int id);
        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetail();


        IResult AddTranstionalTest(Car car);



    }
 
}
