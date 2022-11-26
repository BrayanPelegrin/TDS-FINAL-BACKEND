using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.Entities.IdentityModels;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = new ApiResponse();
            var query = _roleManager.Roles.ToList();
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

        [HttpPost]
        public async Task<IActionResult> Save(IdentityRole role)
        {
            var response = new ApiResponse();

            if (role == null)
            {
                response.Mensaje = "Ocurrio un Error al Crear el Producto";
            }
            else
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Mensaje = "Registro Exitoso";
                    response.Result = role;
                }
                else
                {
                    response.Mensaje = "Ocurrio un Error al Crear el Producto";
                }
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(IdentityRole role)
        {
            var response = new ApiResponse();

            if (role == null)
            {
                response.Mensaje = "Ocurrio un Error al Crear el Producto";
            }
            else
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Mensaje = "Registro Exitoso";
                    response.Result = role;
                }
                else
                {
                    response.Mensaje = "Ocurrio un Error al Crear el Producto";
                }
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = new ApiResponse();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                response.Mensaje = "El Producto no existe";
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Mensaje = "Eliminacion Exitosa";
                    response.Result = role;
                }
                else
                {
                    response.Mensaje = "Ocurrio un Error al eliminar el Producto";
                }
            }
            return Ok(response);
        }

        [HttpPost("{idRole}/{idUser}")]
        [Route("AsignRole")]
        public async Task<IActionResult> Save(string idRole, string idUser)
        {
            var response = new ApiResponse();

            if (string.IsNullOrEmpty(idRole) || string.IsNullOrEmpty(idRole))
            {
                response.Mensaje = "Uno de los Id no es valido";
            }
            else
            {
                var resultRole = await _roleManager.FindByIdAsync(idRole);
                var resultuser = await _userManager.FindByIdAsync(idUser);

                if (resultRole != null && resultuser != null)
                {
                    var result = await _userManager.AddToRoleAsync(resultuser, resultRole.Name);
                    if (result.Succeeded)
                    {
                        response.Success = true;
                        response.Mensaje = "Asignacion Exitosa";
                        response.Result = new { User = resultuser.UserName, Role = resultRole.Name };
                    }
                    else
                    {
                        response.Mensaje = "Ocurrio un Error al Asignar el Rol";
                    }
                    
                }
                else
                {
                    response.Mensaje = "Ocurrio un Error al Crear el Producto";
                }
            }
            return Ok(response);
        }
    }
}
