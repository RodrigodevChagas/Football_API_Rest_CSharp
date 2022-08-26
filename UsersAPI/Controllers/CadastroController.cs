using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createUsuario) {

            Result resultado = _cadastroService.CadastraUsuario(createUsuario);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes.First());
        }
    }
}
