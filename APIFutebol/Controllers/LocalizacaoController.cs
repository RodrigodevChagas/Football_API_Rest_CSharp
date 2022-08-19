using APIFutebol.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIFutebol.Data.Dtos.LocalizacaoDto;
using System.Collections;
using APIFutebol.Data.Dtos;
using APIFutebol.Services;
using FluentResults;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private LocalizacaoService _localizacaoService;

        public LocalizacaoController( LocalizacaoService localizacaoService)
        {
            _localizacaoService = localizacaoService;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarLocalizacao([FromBody] PostEPutLocalizacaoDto request)
        {

            GetLocalizacaoDto requestDto = _localizacaoService.AdicionarLocalizacao(request);
            return CreatedAtAction(nameof(RecuperaLocalizacaoPorId), new { Id = requestDto.Id }, requestDto);
        }


        // Retorna todos os confrontos
        [HttpGet]
        public IActionResult RecuperarLocalizacao()
        {
            List<GetLocalizacaoDto> request = _localizacaoService.RecuperaLocalizacao();
            if (request != null) return Ok(request);
            return NotFound();
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperaLocalizacaoPorId(int id)
        {

            GetLocalizacaoDto request = _localizacaoService.RecuperaLocalizacaoPorId(id);  

            if (request != null) return Ok(request);
            return NotFound();
        }

        //quero receber um int e devolver e devolver 3 localizações, duas dos times e uma do local que esta sendo cediado as partidas.

        [HttpPut("{id}")]
        public IActionResult AtualizaLocalizacao(int id, [FromBody] PostEPutLocalizacaoDto request)
        {


            Result result = _localizacaoService.AtualizaLocalizacao(id, request);

            if (result.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLocalizacao(int id)
        {

            Result result = _localizacaoService.DeletaLocalizacao(id);

            if (result.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}