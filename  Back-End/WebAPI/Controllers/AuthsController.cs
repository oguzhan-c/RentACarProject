using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstruct;
using Entities.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : Controller
    {
        private IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Succcess)
            {                                                                                                                                                               
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Succcess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (userExists.Succcess)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Succcess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
