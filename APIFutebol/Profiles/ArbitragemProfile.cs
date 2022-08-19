using APIFutebol.Data.Dtos.ArbitragemDto;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class ArbitragemProfile : Profile
    {
        public ArbitragemProfile()
        {
            CreateMap<PostEPutArbitragemDto, Arbitragem>();
            CreateMap<Arbitragem, GetArbitragemDto>();
        }
    }
}
