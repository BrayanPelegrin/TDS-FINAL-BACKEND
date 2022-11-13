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
                .ForPath(src=> src.Categoria.Descripcion, dst => dst.MapFrom(opt => opt.Categoria.Descripcion)).ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
                
        }
    }
}
