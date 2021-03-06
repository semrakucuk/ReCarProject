﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email); 
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);  
        IResult Add(User car);
        IResult Delete(User car);
        IResult Update(User car); 
     }
}
