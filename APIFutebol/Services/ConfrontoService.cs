using APIFutebol.Data.Dtos.ConfrontoDto;
using APIFutebol.Models;
using AutoMapper;
using FluentResults;

namespace APIFutebol.Services
{
    public class ConfrontoService
    {
        private FutebolContext _context;
        private IMapper _mapper;

        public ConfrontoService(FutebolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetDto AdicionarConfronto(PostEPutDto requestDto) {

            Confronto confronto = _mapper.Map<Confronto>(requestDto);
            _context.Add(confronto);
            _context.SaveChanges();
            return _mapper.Map<GetDto>(confronto);
        }
        
        public List<GetDto> RecuperarConfronto() {
           
            List<Confronto> confronto = _context.Confrontos.ToList();
            
            if (confronto != null) return _mapper.Map<List<GetDto>>(confronto);
            return null;
        }

        public GetDto RecuperarConfrontoPorId(int id){

            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto => confronto.Id == id);
            
            if (confronto != null){
                GetDto requestDto = _mapper.Map<GetDto>(confronto);
                return requestDto;
            }
            return null;
        }

        public Result AtualizarConfronto(int id, PostEPutDto requestDto) {

            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto => confronto.Id == id);
            if (confronto != null) {

                _mapper.Map(requestDto, confronto);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Confronto não encontrado");
        }

        public Result DeletaConfronto(int id) {

            Confronto confronto = _context.Confrontos.FirstOrDefault(confronto => confronto.Id == id);
            if (confronto != null) {

                _context.Remove(confronto);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Confronto não encontrado");
        }
    }
}
