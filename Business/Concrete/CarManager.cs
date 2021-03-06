using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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

        [CacheAspect]
        [PerformanceAspect(1)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(),  Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _calDal.Get(x => x.CarId == id) , Messages.CarListed);
        } 
        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max), Messages.CarListed);
        } 
        public IDataResult<List<Car>> GetOrByBrand(int id)
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(x => x.BrandId == id));
        } 
        public IDataResult<List<Car>> GetOrByColor(int id)
        {
            return new SuccessDataResult<List<Car>>(_calDal.GetAll(x => x.ColorId == id));
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
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

        [CacheRemoveAspect("ICarService.Get")]
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
            return new SuccessDataResult<List<CarDetailDto>>(_calDal.GetCarDetail());
        }

        [TransactionScopeAspect]
        public IResult AddTranstionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception(Messages.NotAdded);
            }

            Add(car);

            return new SuccessResult(Messages.AddTransactionalTest);

        }
    }
}
