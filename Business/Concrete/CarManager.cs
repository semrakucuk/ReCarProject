using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _calDal;

        public CarManager(ICarDal calDal)
        {
            _calDal = calDal;
        }



        public List<Car> GetAll()
        {
            return _calDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _calDal.Get(x => x.CarId == id);
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _calDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max);
        }

        public List<Car> GetOrByBrand(int id)
        {
            return _calDal.GetAll(x => x.BrandId == id);
        }

        public List<Car> GetOrByColor(int id)
        {
            return _calDal.GetAll(x => x.ColorId == id);
        }
        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.CarName.Length >= 2)
                {
                    _calDal.Add(car);
                    Console.WriteLine("Yeni Kayıt Ekleme Başarılı");
                }
                else
                {
                    Console.WriteLine("Araba Adı en az iki karakterden oluşmalıdır.");
                }
            }
            else
            {
                Console.WriteLine("Günlük Fiyat Sıfırdan büyük olmalı");
            }
        }

        public void Delete(Car car)
        {
            _calDal.Delete(car);
            Console.WriteLine("Silme Başarılı");
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.CarName.Length >= 2)
                {
                    _calDal.Update(car);
                    Console.WriteLine("Güncelleme Başarılı");
                }
                else
                {
                    Console.WriteLine("Arama Adı en az iki karakterden oluşmalıdır.");
                }
            }
            else
            {
                Console.WriteLine("Günlük Fiyat Sıfırdan büyük olmalı");
            }
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _calDal.GetCarDetail();
        }
    }
}
