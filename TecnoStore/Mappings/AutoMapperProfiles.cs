using AutoMapper;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Entities;

namespace TecnoStore.Api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
                
        }
    }
}
