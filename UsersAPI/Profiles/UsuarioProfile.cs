using AutoMapper;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
         
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
