using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCarContext context=new ReCarContext())
            {
                var result = from x in context.Cars
                             join c in context.Colors 
                             on x.ColorId equals c.ColorId
                             join b in context.Brands
                             on x.BrandId equals b.BrandId
                             select new CarDetailDto
                             { 
                                 BrandName=b.BrandName,
                                ColorName=c.ColorName ,
                                CarName=x.CarName ,
                                 DailyPrice = x.DailyPrice  
                             };
                return result.ToList();
            }
        }
    }
}
