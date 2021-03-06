﻿using Core.Utilities.Results.Abstruct;
using DataAccess.Abstruct;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrute;

namespace Business.Abstruct
{
    public interface IUserService
    {
        IDataResult<List<UserDetailsDto>> GetUsersDetails();
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user); 
        IDataResult<User> GetByMail(string email);
    }
}
