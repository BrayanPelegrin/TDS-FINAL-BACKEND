using AutoMapper;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Entities;

namespace TecnoStore.Api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, ProductoDTO>()
                .ForMember(src=>src.Categoria, dst => dst.MapFrom(opt=> opt.Categoria))
                
                .ReverseMap();

            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(src => src.Productos, dst => dst.MapFrom(opt => opt.Productos)).ReverseMap();
                
        }
    }
}
