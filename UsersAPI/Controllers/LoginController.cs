using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Requests;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request) {

            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes.First());
        }
    }
}
