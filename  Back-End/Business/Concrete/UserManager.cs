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
using Core.Entities.Concrute;

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
                    CheckIfUserAlreadyDeleted(user.Id)
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
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == id),UserMessages.ListedById);
        }

        public IDataResult<List<UserDetailsDto>> GetUsersDetails()
        {
            var result = _userDal.GetUserDetails();
            if (result.Succcess)
            {
                return new SuccessDataResult<List<UserDetailsDto>>(result.Data);
            }

            return new ErrorDataResult<List<UserDetailsDto>>(UserMessages.UserDetailsİsNotExist);
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
            var result = _userDal.GetAll(u => u.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(UserMessages.UserAlreadyDeleted);
            }
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result.Succcess)
            {
                return new SuccessDataResult<List<OperationClaim>>(result.Data);
            }

            return new ErrorDataResult<List<OperationClaim>>(UserMessages.ClaimsDoNotExist);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.GetAll(u => u.UserEmail == email).Any();
            if (result)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.UserEmail == email));
            }

            return new ErrorDataResult<User>(UserMessages.MailIsNotExist);
        }
    }
}
