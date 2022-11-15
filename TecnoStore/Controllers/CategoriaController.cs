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
        public IActionResult Get()
        {
            var response = new ApiResponse();
            var query =  _repository.GetAllWithInclude(x=>x.Productos);
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
        public IActionResult Save(CategoriaDTO categoria)
        {
            var CategoriaMapeada =  _mapper.Map<Categoria>(categoria);
            var CategoriaGuardada =  _repository.Save(CategoriaMapeada);
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
        public IActionResult Update(CategoriaDTO categoria, int id)
        {
            var response = new ApiResponse();
            var CategoriaBuscada = _repository.GetById(id);
            if (CategoriaBuscada == null)
            {
                response.Mensaje = "La Categoria no existe";
            }
            else
            {
                CategoriaBuscada = _mapper.Map<Categoria>(categoria);
                var CategoriaGuardada = _repository.Save(CategoriaBuscada);


                if (CategoriaGuardada == null)
                {
                    response.Mensaje = "Ocurrio un Error al actualizar La Categoria";
                }
                else
                {
                    response.Success = true;
                    response.Mensaje = "Actualizacion Exitosa";
                    response.Result = CategoriaGuardada;
                }
            }

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var response = new ApiResponse();
            var CategoriaBuscada =  _repository.GetById(id);
            if (CategoriaBuscada == null)
            {
                response.Mensaje = "La Categoria no existe";
            }
            else
            {
                CategoriaBuscada =  _repository.Delete(CategoriaBuscada);
                response.Success = true;
                response.Mensaje = "Registro Exitoso";
                response.Result = CategoriaBuscada;
            }


            return Ok(response);
        }
    }
}
