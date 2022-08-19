using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIFutebol.Models;
using System.Collections;
using APIFutebol.Data.Dtos.ResultadoDto;
using APIFutebol.Data.Dtos;
using APIFutebol.Services;
using FluentResults;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadoController : ControllerBase
    {
        private ResultadoService _resultadoService;

        public ResultadoController(ResultadoService resultadoService)
        {
            _resultadoService = resultadoService;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarResultado([FromBody] PostEPutResultadoDto request)
        {

            GetResultadoDto resultado = _resultadoService.AdicionaResultado(request);

            return CreatedAtAction(nameof(RecuperaResultadoPorId), new { Id = resultado.Id }, resultado);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IActionResult RecuperarResultado(){

            List<GetResultadoDto> resultado = _resultadoService.RecuperaResultado();
           
            if (resultado != null) return Ok(resultado);
            return NotFound();
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaResultadoPorId(int id){

            GetResultadoDto resultado = _resultadoService.RecuperaResultadoPorId(id);

            if (resultado != null) return Ok(resultado);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaResultado(int id, [FromBody] PostEPutResultadoDto requestDto)
        {


            Result resultado = _resultadoService.AtualizaResultado(id, requestDto);
            if (resultado.IsSuccess) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaResultado(int id)
        {

            Result resultado = _resultadoService.DeletaResultado(id);

            if (resultado.IsSuccess) return NotFound();
            return NoContent();
        }
    }
}
