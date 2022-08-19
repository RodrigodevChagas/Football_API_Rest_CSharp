using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;

namespace UsersAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createUsuario) {

            return Ok();
        }
    }
}
