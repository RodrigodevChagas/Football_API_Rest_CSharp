using APIFutebol.Data.Dtos.ConfrontoDto;
using APIFutebol.Models;
using AutoMapper;

namespace APIFutebol.Profiles
{
    public class ConfrontoProfile : Profile
    {
        public ConfrontoProfile()
        {
            CreateMap<PostEPutDto, Confronto>();
            CreateMap<Confronto, GetDto>();
        }
    }
}
