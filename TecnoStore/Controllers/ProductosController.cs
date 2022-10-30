using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.DTOs;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Save(ProductoDTO producto)
        {
            return Ok(producto);
        }

        [HttpPut]
        public IActionResult Update() 
        {
            return Ok();   
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }


    }
}
