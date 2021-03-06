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
            //ColorTest();
            //BrandTest();
            //ColorTestAddUpdateDelete();
            //GetCarDetailTest();
            // NewUserTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId=2,
                RentDate=DateTime.Now, 
            }); 
        }

        private static void NewUserTest()
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //User user1 = new User()
            //{
            //    Email = "semrakucuk97@gmail.com",
            //    Password = "*123*",
            //    FirstName = "Semra",
            //    LastName = "KÜÇÜK"
            //};
            //Console.WriteLine(userManager.Add(user1).Message);
        }

        private static void GetCarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "  -  " + car.ColorName + "  -  " + car.BrandName + "  -  " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        } 
        private static void ColorTestAddUpdateDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {

                ColorName = "KIRMIZI",
                ColorId = 1,
            };
            colorManager.Update(color);

            //Color color = new Color()
            //{
            //    ColorName = "GRİ",
            //};
            //colorManager.Add(color);

            //Color color = new Color()
            //{
            //    ColorId = 1003
            //};
            //colorManager.Delete(color);
        } 
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll().Data)
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
            Console.WriteLine(brandManager.GetById(3).Data.BrandName);
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        } 
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            ////Renk Kategorisine göre listeleme
            //result = carManager.GetOrByColor(3);
            //if (result.Success == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            ////Kayıt Ekleme
            //Car car1 = new Car()
            //{
            //    CarName = "Mercedes",
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 1000,
            //    ModelYear = "2016",
            //    Description = "Mercedes 2006"
            //};
            //Console.WriteLine(carManager.Add(car1).Message);

            //////Id ye göre getirme
            //Console.WriteLine(carManager.GetById(2).CarName);

        }
    }
}
