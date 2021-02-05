using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //////Tümünü Listeleme 
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}

            //////Renk Kategorisine göre listeleme
            //foreach (var car in carManager.GetOrByColor(3))
            //{
            //    Console.WriteLine(car.CarName);
            //} 

            ////Kayıt Ekleme
            Car car1 = new Car()
            {
                CarName = "Mercedes",
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 1000,
                ModelYear = "2016",
                Description = "Mercedes 2006"
            };
            carManager.Add(car1);


            //////Id ye göre getirme
            //Console.WriteLine(carManager.GetById(2).CarName);


        }
    }
}
