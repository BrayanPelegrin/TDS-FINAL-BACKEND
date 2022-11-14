using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Entities;
using TecnoStore.Core.Interfaces;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes)]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;
        public CategoriaController(IRepository<Categoria> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new ApiResponse();
            var query = await _repository.GetAllWithInclude(x=>x.Productos);
            var queryMapped = _mapper.Map<IEnumerable<CategoriaDTO>>(query);

            if (query.Count() == 0)
            {
                response.Mensaje = "No Hay Registros";
            }
            else
            {
                response.Success = true;
                response.Mensaje = "Consulta Exitosa";
                response.Result = queryMapped;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoriaDTO producto)
        {
            var CategoriaMapeada = new Categoria
            {
                Descripcion = producto.Descripcion,
                EstadoId = (int)Enums.Estados.Activo,
                FechaCreo = DateTime.Now,
                UsuarioCreo = "Admin"
            };
            var CategoriaGuardada = await _repository.SaveAsync(CategoriaMapeada);
            var response = new ApiResponse();

            if (CategoriaGuardada == null)
            {
                response.Mensaje = "Ocurrio un Error al Crear La Categoria";
            }
            else
            {
                response.Success = true;
                response.Mensaje = "Registro Exitoso";
                response.Result = CategoriaGuardada;
            }
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(CategoriaDTO producto, int id)
        {
            var response = new ApiResponse();
            var CategoriaBuscada = await _repository.GetByIdAsync(id);
            if (CategoriaBuscada == null)
            {
                response.Mensaje = "La Categoria no existe";
            }
            else
            {
                var CategoriaMapeada = new Categoria
                {
                    Id = CategoriaBuscada.Id,
                    Descripcion = producto.Descripcion,
                    EstadoId = (int)Enums.Estados.Activo,
                    FechaCreo = DateTime.Now,
                    UsuarioCreo = "Admin"
                };
                var CategoriaGuardada = await _repository.SaveAsync(CategoriaMapeada);


                if (CategoriaGuardada == null)
                {
                    response.Mensaje = "Ocurrio un Error al Crear La Categoria";
                }
                else
                {
                    response.Success = true;
                    response.Mensaje = "Registro Exitoso";
                    response.Result = CategoriaGuardada;
                }
            }

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ApiResponse();
            var CategoriaBuscada = await _repository.GetByIdAsync(id);
            if (CategoriaBuscada == null)
            {
                response.Mensaje = "La Categoria no existe";
            }
            else
            {
                CategoriaBuscada = await _repository.DeleteAsync(CategoriaBuscada);
                response.Success = true;
                response.Mensaje = "Registro Exitoso";
                response.Result = CategoriaBuscada;
            }


            return Ok(response);
        }
    }
}
