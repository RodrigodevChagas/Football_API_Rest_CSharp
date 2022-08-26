using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;
using UsersAPI.Data.Requests;
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

        [HttpPost("/ ativa")]
        public IActionResult AtivaUsuario(AtivaContaRequest request) {

            Result resultado = _cadastroService.AtivaUsuario(request);
            if (resultado.IsSuccess) return Ok();
            return BadRequest();
        }
    }
}
