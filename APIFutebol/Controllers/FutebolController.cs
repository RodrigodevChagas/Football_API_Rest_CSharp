using APIFutebol.Data.Dtos.ConfrontoDto;
using APIFutebol.Models;
using APIFutebol.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APIFutebol.Controllers
{

    [ApiController]
    [Route("api/[controller]")] //Indica rota
    public class FutebolController : ControllerBase
    {
        private ConfrontoService _confrontoService;

        public FutebolController(ConfrontoService confrontoService)
        {
            _confrontoService = confrontoService;
        }

        // Cria metedo que adiciona um confronto na lista confronto
        [HttpPost]
        public IActionResult AdicionarConfronto([FromBody] PostEPutDto requestDto) {

            GetDto request = _confrontoService.AdicionarConfronto(requestDto);
            return CreatedAtAction(nameof(RecuperarConfrontoPorId), new { Id = request.Id }, request);
        }

        // Retorna todos os confrontos
        [HttpGet]
        public IActionResult RecuperarConfronto(){

            List<GetDto> getDto = _confrontoService.RecuperarConfronto();
            if (getDto != null) return Ok(getDto);
            return NotFound();    
        }

        // Retorna confronto por id
        [HttpGet("{id}")]
        public IActionResult RecuperarConfrontoPorId (int id)
        {

            GetDto requestDto = _confrontoService.RecuperarConfrontoPorId(id);
            
            if (requestDto != null) return Ok(requestDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaConfronto(int id, [FromBody] PostEPutDto requestDto) {


            Result result = _confrontoService.AtualizarConfronto(id, requestDto);

            if (result.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaConfronto(int id) {

            Result result = _confrontoService.DeletaConfronto(id);
            
            if (result.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
