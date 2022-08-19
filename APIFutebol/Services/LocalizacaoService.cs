using APIFutebol.Data.Dtos.LocalizacaoDto;
using APIFutebol.Models;
using AutoMapper;
using FluentResults;

namespace APIFutebol.Services
{
    public class LocalizacaoService
    {
        private IMapper _mapper;
        private FutebolContext _context;

        public LocalizacaoService(IMapper mapper, FutebolContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetLocalizacaoDto AdicionarLocalizacao(PostEPutLocalizacaoDto requestDto) {

            Localizacao localizacao = _mapper.Map<Localizacao>(requestDto);
            _context.Localizacoes.Add(localizacao);
            _context.SaveChanges();
            return _mapper.Map<GetLocalizacaoDto>(localizacao);
        }

        public List<GetLocalizacaoDto> RecuperaLocalizacao() {

            List<Localizacao> requestDto = _context.Localizacoes.ToList();
            if (requestDto != null) return _mapper.Map<List<GetLocalizacaoDto>>(requestDto);
            return null;
        }

        public GetLocalizacaoDto RecuperaLocalizacaoPorId(int id) {

            Localizacao localizacao = _context.Localizacoes.FirstOrDefault(localizacao => localizacao.Id == id);
            if (localizacao != null) return _mapper.Map<GetLocalizacaoDto>(localizacao);
            return null;
        }

        public Result AtualizaLocalizacao(int id, PostEPutLocalizacaoDto requestDto) {

            Localizacao localizacao = _context.Localizacoes.FirstOrDefault(localizacao => localizacao.Id == id);
            if (localizacao != null) {
                _mapper.Map(requestDto, localizacao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Localizacao não encontrada");
        }

        public Result DeletaLocalizacao(int id) {

            Localizacao localizacao = _context.Localizacoes.FirstOrDefault(localizacao => localizacao.Id == id);
         
            if (localizacao != null) {

                _context.Localizacoes.Remove(localizacao);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Localizacao não encontrada");
        }
    }
}
