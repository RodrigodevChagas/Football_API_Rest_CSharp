using APIFutebol.Data.Dtos;
using APIFutebol.Data.Dtos.ArbitragemDto;
using APIFutebol.Models;
using APIFutebol.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace APIFutebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArbitragemController : ControllerBase
    {
        private ArbitragemService _arbitragemService;

        public ArbitragemController(ArbitragemService arbitragemService)
        {
            _arbitragemService = arbitragemService;
        }

        [HttpPost]
        public IActionResult AdicionaArbitragem(PostEPutArbitragemDto requestDto) {

            GetArbitragemDto request = _arbitragemService.AdicionaArbitragem(requestDto);
            return CreatedAtAction(nameof(RecuperaArbitragemPorId), new { Id = request.Id }, request);
        }

        [HttpGet]
        public IActionResult RecuperaArbitragem() {
            
            List<GetArbitragemDto> arbitragemDto = _arbitragemService.RecuperaArbitragem();
            if(arbitragemDto != null ) return Ok(arbitragemDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaArbitragemPorId(int id)
        {

            GetArbitragemDto requestDto = _arbitragemService.RecuperaArbitragemPorId(id);

            if (requestDto != null) return Ok(requestDto);
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaArbitragem(int id, PostEPutArbitragemDto requestDto) {

            Result result = _arbitragemService.AtualizaArbitragem(id, requestDto);
            
            if(result.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaArbitragem(int id) {

            Result result = _arbitragemService.DeletaArbitragem(id);
            
            if (result.IsSuccess) return NoContent();
            return NotFound();
        }

    }
}
