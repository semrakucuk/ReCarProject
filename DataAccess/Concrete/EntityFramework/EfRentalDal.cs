 using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,ReCarContext> , IRentalDal
    {
        //Hata Var
        //public List<RentalDetailDto> GetRentalDetail()
        //{
        //    using (ReCarContext context = new ReCarContext())
        //    {
        //        var result = from y in context.Rentals
        //                     join c in context.Colors
        //                     on x.ColorId equals c.ColorId
        //                     join b in context.Brands
        //                     on x.BrandId equals b.BrandId
        //                     select new CarDetailDto
        //                     {
        //                         BrandName = b.BrandName,
        //                         ColorName = c.ColorName,
        //                         CarName = x.CarName,
        //                         DailyPrice = x.DailyPrice
        //                     };
        //        return result.ToList();
        //    }
        //}
    }
}
