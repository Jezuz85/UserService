using AutoMapper;
using UserService.Core.Dtos;
using UserService.Core.Entities;

namespace UserService.Api.map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoDTO, Producto>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.ToUpper()))
                .ReverseMap();
        }
    }
}