using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Business.Interfaces;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Domain.Business.Services;
using Helper.Interfaces;


namespace TicketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        ITokenService _tokenService;
        public AuthController(IAuthService authService , ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {

            // Validation eklemeyi dusunebilirsin...

            var user = _authService.RegisterAsync(dto);
            return Ok("Kayıt başarılı!");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {

            // Validation eklemeyi dusunebilirsin...

            var user = _authService.LoginAsync(dto.Username,dto.Password).Result;

            if(user == null)
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış.");
            }

            string tokenString =  _tokenService.GenerateToken(user);
            

            return Ok(new
            {
                token = tokenString,
                role = user.Role,
                userId = user.Id
            });
        }



    }
}
