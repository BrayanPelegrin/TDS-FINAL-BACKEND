using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Entities;
using TecnoStore.Core.Interfaces;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IRepository<Producto> _repository;
        private readonly IMapper _mapper;

        public ProductosController(IRepository<Producto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var response = new ApiResponse();
            var query = _repository.GetAllWithInclude(x=> x.Categoria);
            var queryMapped = _mapper.Map<IEnumerable<ProductoDTO>>(query);
       
            if(queryMapped.Count() == 0)
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

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var response = new ApiResponse();
            var query = _repository.GetByIdWithInclude(id, x=>x.Categoria);
            var queryMapped = _mapper.Map<IEnumerable<ProductoDTO>>(query);

            if (queryMapped == null)
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
        public IActionResult Save(ProductoDTO producto)
        {
            var ProductoMapeado = _mapper.Map<Producto>(producto);

             var ProductoGuardado =  _repository.Save(ProductoMapeado);
            var response = new ApiResponse();

            if (ProductoGuardado == null)
            {
                response.Mensaje = "Ocurrio un Error al Crear el Producto";
            }
            else
            {
                response.Success = true;
                response.Mensaje = "Registro Exitoso";
                response.Result = ProductoGuardado;
            }
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(ProductoDTO producto, int id) 
        {
            var response = new ApiResponse();
            var productoBuscado = _repository.GetById(id);
            if (productoBuscado == null)
            {
                response.Mensaje = "El Producto no existe";
            }
            else
            {
                productoBuscado = _mapper.Map<Producto>(producto);
                var ProductoGuardado = _repository.Save(productoBuscado);


                if (ProductoGuardado == null)
                {
                    response.Mensaje = "Ocurrio un Error al Crear el Producto";
                }
                else
                {
                    response.Success = true;
                    response.Mensaje = "Registro Exitoso";
                    response.Result = ProductoGuardado;
                }
            }
            
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var response = new ApiResponse();
            var productoBuscado = _repository.GetById(id);
            if (productoBuscado == null)
            {
                response.Mensaje = "El Producto no existe";
            }
            else
            {
                productoBuscado = _repository.Delete(productoBuscado);
                response.Success = true;
                response.Mensaje = "Registro Exitoso";
                response.Result = productoBuscado;
            }


                return Ok(response);
        }
        // ESTE METODO ES PARA PROBAR EL TOKEN, MAS ADELANTE SERA APLICADO A TODOS LOS ENDPOINTS
        [Authorize]
        [HttpGet]
        [Route("JWT")]
        public IActionResult GetWithJWT()
        {
            var response = new ApiResponse();
            var query = _repository.GetAllWithInclude(x => x.Categoria).ToList();
            var queryMapped = _mapper.Map<IEnumerable<ProductoDTO>>(query);

            if (queryMapped.Count() == 0)
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


    }
}
