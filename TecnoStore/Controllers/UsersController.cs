using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.Entities.IdentityModels;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {

            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = new ApiResponse();
            var query = _userManager.Users.ToList();
            if (query.Count() == 0)
            {
                response.Mensaje = "No Hay Registros";
            }
            else
            {
                response.Success = true;
                response.Mensaje = "Consulta Exitosa";
                response.Result = query;
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = new ApiResponse();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                response.Mensaje = "El Producto no existe";
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Mensaje = "Eliminacion Exitosa";
                    response.Result = user;
                }
                else
                {
                    response.Mensaje = "Ocurrio un Error al eliminar el Producto";
                }
            }
            return Ok(response);
        }
    }
}
