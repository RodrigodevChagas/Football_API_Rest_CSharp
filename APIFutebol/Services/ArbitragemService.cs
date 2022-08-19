using APIFutebol.Data.Dtos.ArbitragemDto;
using APIFutebol.Models;
using AutoMapper;
using FluentResults;

namespace APIFutebol.Services
{
    public class ArbitragemService
    {

        private FutebolContext _context;
        private IMapper _mapper;

        public ArbitragemService(FutebolContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public GetArbitragemDto AdicionaArbitragem(PostEPutArbitragemDto requestDto) {

            Arbitragem arbitragem = _mapper.Map<Arbitragem>(requestDto);
            _context.Arbitragens.Add(arbitragem);
            _context.SaveChanges();
            return _mapper.Map<GetArbitragemDto>(arbitragem);
        }

        public List<GetArbitragemDto> RecuperaArbitragem() {

            List<Arbitragem> arbitragens = _context.Arbitragens.ToList();
            
            if (arbitragens != null) return _mapper.Map<List<GetArbitragemDto>>(arbitragens);
            return null;
        }

        public GetArbitragemDto RecuperaArbitragemPorId(int id) {
            
            Arbitragem arbitragem = _context.Arbitragens.FirstOrDefault(arbitragem => arbitragem.Id == id);
            if (arbitragem != null)
            {

                GetArbitragemDto requestDto = _mapper.Map<GetArbitragemDto>(arbitragem);
                return requestDto;
            }
            return null;
        }

        public Result AtualizaArbitragem(int id, PostEPutArbitragemDto requestDto) {

            Arbitragem arbitragem = _context.Arbitragens.FirstOrDefault(arbitragem => arbitragem.Id == id);
            if (arbitragem != null) {

                _mapper.Map(requestDto, arbitragem);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Membro de arbitragem não encontrado");
        }

        public Result DeletaArbitragem(int id) {

            Arbitragem arbitragem = _context.Arbitragens.FirstOrDefault(arbitragem => arbitragem.Id == id);
            if (arbitragem != null) {

                _context.Remove(arbitragem);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Membro de arbitragem não encontrado");
        }
    }
}
