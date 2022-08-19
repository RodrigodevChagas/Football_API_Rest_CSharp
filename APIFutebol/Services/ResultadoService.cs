using APIFutebol.Data.Dtos.ResultadoDto;
using APIFutebol.Models;
using AutoMapper;
using FluentResults;

namespace APIFutebol.Services
{
    public class ResultadoService
    {
        private IMapper _mapper;
        private FutebolContext _context;

        public ResultadoService(IMapper mapper, FutebolContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetResultadoDto AdicionaResultado(PostEPutResultadoDto requestDto) {

            Resultado resultado = _mapper.Map<Resultado>(requestDto);
            
            _context.Resultados.Add(resultado);
            _context.SaveChanges();
            
            return _mapper.Map<GetResultadoDto>(resultado);
        }

        public List<GetResultadoDto> RecuperaResultado() {
        
            List<Resultado> resultados = _context.Resultados.ToList();
            
            if (resultados != null) return _mapper.Map<List<GetResultadoDto>>(resultados);
            return null;
        }

        public GetResultadoDto RecuperaResultadoPorId(int id) {

            Resultado resultado = _context.Resultados.FirstOrDefault(resultado => resultado.Id == id);
            
            if (resultado != null) return _mapper.Map<GetResultadoDto>(resultado);
            return null;
        }

        public Result AtualizaResultado(int id, PostEPutResultadoDto requestDto)
        {

            Resultado resultado = _context.Resultados.FirstOrDefault(resultado => resultado.Id == id);
            if (resultado != null)
            {

                _mapper.Map(requestDto, resultado);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Resultado não encontrado");
        }

        public Result DeletaResultado(int id) {

            Resultado resultado = _context.Resultados.FirstOrDefault(resultado => resultado.Id == id);
            if (resultado != null){

                _context.Resultados.Remove(resultado);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Resultado não encontrado");
        }
    }
}
