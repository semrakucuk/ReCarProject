using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation.FluentValidation;
using Core.Utilities;
using Core.Utilities.Constant;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(),true , Messages.CarListed);
        } 
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _calDal.Get(x => x.CarId == id) ,true , Messages.CarListed);
        } 
        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max), true, Messages.CarListed);
        } 
        public IDataResult<List<Car>> GetOrByBrand(int id)
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(x => x.BrandId == id),true);
        } 
        public IDataResult<List<Car>> GetOrByColor(int id)
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(x => x.ColorId == id),true);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _calDal.Add(car);
            return new SuccessResult( Messages.CarAdded );  
        }

        public IResult Delete(Car car)
        {
            _calDal.Delete(car);
            Console.WriteLine("Silme Başarılı");
            return new SuccessResult();
        }

        public IResult Update(Car car)
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
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_calDal.GetCarDetail(), true);
        } 
    }
}
