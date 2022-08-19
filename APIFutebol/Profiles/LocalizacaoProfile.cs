using APIFutebol.Data.Dtos.LocalizacaoDto;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class LocalizacaoProfile : Profile
    {
        public LocalizacaoProfile()
        {
            CreateMap<PostEPutLocalizacaoDto, Localizacao>();
            CreateMap<Localizacao, GetLocalizacaoDto>();
        }
    }
}
