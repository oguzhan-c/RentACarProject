﻿using Business.Abstruct;
using Business.Constat;
using Core.Entities.Concrute;
using Core.Utilities.Results.Abstruct;
using Core.Utilities.Results.Concrute;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            HashingHelper.CreatepasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserEmail = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Succcess )
            {
                return new ErrorDataResult<User>(userToCheck.Message);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {                                                                                                                                                                                           
                return new ErrorDataResult<User>(UserMessages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data,UserMessages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Succcess)
            {
                return new SuccessResult(UserMessages.UserAlreadyExist);
            }
            return new ErrorResult(UserMessages.UserNotFound);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.createToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,UserMessages.AccessTokenCreated);
        }
    }
}