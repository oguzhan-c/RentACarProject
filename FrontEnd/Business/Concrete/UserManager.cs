using Business.Abstruct;
using Business.Constat;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using DataAccess.Abstruct.DataAcessLayers;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            IResult result = BusinessRule.Run
                (
                    CheckIfUserAlreadyExist(user.UserEmail)
                );
            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(UserMessages.Added);
        }

        public IResult Delete(User user)
        {
            IResult result = BusinessRule.Run
                (
                    CheckIfUserAlreadyDeleted(user.UserId)
                );
            _userDal.Delete(user);
            return new SuccessResult(UserMessages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),UserMessages.Listed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == id),UserMessages.ListedById);
        }

        public IDataResult<List<UserDetailsDto>> GetUsersDetails()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetUserDetails(),UserMessages.UserDetaislListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.Updated);
        }

        private IResult CheckIfUserAlreadyExist(String email)
        {
            var result = _userDal.GetAll(u => u.UserEmail == email).Any();
            if (result)
            {
                return new ErrorResult(UserMessages.UserAlreadyExist);
            }
            return new SuccessResult(UserMessages.Added);
        }

        private IResult CheckIfUserAlreadyDeleted(int id)
        {
            var result = _userDal.GetAll(u => u.UserId == id).Any();

            if (!result)
            {
                return new ErrorResult(UserMessages.UserAlreadyDeleted);
            }
            return new SuccessResult();
        }

    }
}
