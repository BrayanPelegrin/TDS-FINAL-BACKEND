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
        public async Task<IActionResult> Get() 
        {
            var response = new ApiResponse();
            var query = await Task.FromResult(_repository.GetAllWithInclude(x=> x.Categoria).Result.ToList());
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

        [HttpPost]
        public async Task<IActionResult> Save(ProductoDTO producto)
        {
            var ProductoMapeado = _mapper.Map<Producto>(producto);

             var ProductoGuardado = await _repository.SaveAsync(ProductoMapeado);
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
        public async Task<IActionResult> Update(ProductoDTO producto, int id) 
        {
            var response = new ApiResponse();
            var productoBuscado = await _repository.GetByIdAsync(id);
            if (productoBuscado == null)
            {
                response.Mensaje = "El Producto no existe";
            }
            else
            {
                var ProductoMapeado = new Producto
                {
                    Id = productoBuscado.Id,
                    Nombre = producto.Nombre,
                    CategoriaId = producto.CategoriaId,
                    Descripcion = producto.Descripcion,
                    EstadoId = (int)Enums.Estados.Activo,
                    Stock = producto.Stock,
                    Precio = producto.Precio,
                    FechaCreo = DateTime.Now,
                    UsuarioCreo = "Admin"
                };
                var ProductoGuardado = await _repository.SaveAsync(ProductoMapeado);


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
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ApiResponse();
            var productoBuscado = await _repository.GetByIdAsync(id);
            if (productoBuscado == null)
            {
                response.Mensaje = "El Producto no existe";
            }
            else
            {
                productoBuscado = await _repository.DeleteAsync(productoBuscado);
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
        public async Task<IActionResult> GetWithJWT()
        {
            var response = new ApiResponse();
            var query = await Task.FromResult(_repository.GetAllWithInclude(x => x.Categoria).Result.ToList());
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
