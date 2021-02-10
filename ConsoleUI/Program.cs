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
            // CarTest(); 
            // ColorTest();
            // BrandTest();

            // ColorTestAddUpdateDelete();



            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.CarName + "  -  " + car.ColorName + "  -  " + car.BrandName + "  -  " + car.DailyPrice);
            }
        }

        private static void ColorTestAddUpdateDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Color color = new Color()
            //{

            //    ColorName = "KIRMIZI", 
            //    ColorId = 1, 
            //};
            //colorManager.Update(color);

            //Color color = new Color()
            //{ 
            //    ColorName = "GRİ", 
            //};
            //colorManager.Add(color);

            //Color color = new Color()
            //{
            //    ColorId=1003
            //};
            //colorManager.Delete(color);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
            Console.WriteLine(brandManager.GetById(3).BrandName);
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        } 
        private       static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

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
