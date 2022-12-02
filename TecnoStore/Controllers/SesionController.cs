using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Entities.IdentityModels;
using TecnoStore.Core.Interfaces;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ITokenManager<ApplicationUser> _tokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SesionController(ITokenManager<ApplicationUser> tokenGenerator, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: UsuarioController

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            var response = new ApiResponse();
            var isSuccess = await _signInManager.PasswordSignInAsync(user.Email, user.Password, isPersistent: false, lockoutOnFailure: false);
            if (isSuccess.Succeeded)
            {
                var usuario = await _userManager.FindByEmailAsync(user.Email);
                var token =  _tokenGenerator.TokenGenerator(usuario);
                response.Success = true;
                response.Mensaje = "Inicio de Sesion Exitoso!";
                response.Result = token;
            }
            else
            {
                response.Mensaje = "Credenciales no Validas";
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsuarioDTO user)
        {
            var response = new ApiResponse();
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                response.Mensaje = "El Usuario es invalido";
                return BadRequest(response);
            }
            var userToCreate = new ApplicationUser
            {
                NombreCompleto = user.NombreCompleto,
                UserName = user.Email,
                Email = user.Email,
            };

            var isSuccess = await _userManager.CreateAsync(userToCreate, user.Password);
            if (isSuccess.Succeeded)
            {
                var token = _tokenGenerator.TokenGenerator(userToCreate);
                response.Success = true;
                response.Mensaje = "Usuario Creado Exitosamente";
                response.Result = token;
            }
            else
            {
                response.Mensaje = "Ocurrio Un Error";
            }

            return Ok(response);
        }

    }
}
