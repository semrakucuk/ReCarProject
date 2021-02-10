using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId= 1 , CarName="a", BrandId=1 , ColorId=2 , DailyPrice= 100 , ModelYear= "2000" ,Description="2000 Model Araba"  },
                 new Car{ CarId= 2, CarName="b",BrandId=1 , ColorId=2 , DailyPrice= 300 , ModelYear= "2002" ,Description="2002 Model Araba"  },
                  new Car{ CarId= 3, CarName="c",BrandId=2 , ColorId=2 , DailyPrice= 500 , ModelYear= "2002" ,Description="2002 Model Araba"  },
                   new Car{ CarId= 4, CarName="d",BrandId=2 , ColorId=2 , DailyPrice= 800 , ModelYear= "2003" ,Description="2003 Model Araba"  },
                    new Car{ CarId= 5, CarName="e",BrandId=1 , ColorId=2 , DailyPrice= 1000 , ModelYear= "2006" ,Description="2006 Model Araba"  }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _cars.Where(x => x.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(x => x.CarId == car.CarId);
            carToUpdate.CarName = car.CarName;
            carToUpdate.BrandId = car.BrandId; 
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;   
        }

      
    }
}
