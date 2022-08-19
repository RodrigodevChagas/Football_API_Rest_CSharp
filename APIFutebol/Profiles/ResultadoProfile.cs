using APIFutebol.Data.Dtos.ResultadoDto;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            CreateMap<PostEPutResultadoDto, Resultado>();
            CreateMap<Resultado, GetResultadoDto>();
        }
    }
}
