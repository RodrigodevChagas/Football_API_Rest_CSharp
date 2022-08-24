using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult LogoutUsuario(){

            Result resultado = _logoutService.LogoutUsuario();
            if (resultado.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}
