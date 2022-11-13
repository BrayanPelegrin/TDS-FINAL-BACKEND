using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Interfaces;
using TecnoStore.Core.Services;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenManager<UsuarioDTO> _tokenGenerator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(ITokenManager<UsuarioDTO> tokenGenerator, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: UsuarioController

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDTO user)
        {
            var response = new ApiResponse();
            var isSuccess = await _signInManager.PasswordSignInAsync(user.Correo, user.Password, isPersistent: false, lockoutOnFailure: false);
            if (isSuccess.Succeeded)
            {
                var token = _tokenGenerator.TokenGenerator(user);
                response.Success = true;
                response.Mensaje = "Inicio de Sesion Exitoso!";
                response.Result = _tokenGenerator.TokenGenerator(user);
            }
            else
            {
                response.Mensaje = "Credenciales no Validas";
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Register(UsuarioDTO user)
        {
            var response = new ApiResponse();
            if (user == null || string.IsNullOrEmpty(user.Correo) || string.IsNullOrEmpty(user.Password))
            {
                response.Mensaje = "El Usuario es invalido";
                return BadRequest(response);
            }
            var userToCreate = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Correo,
            };

            var isSuccess = await _userManager.CreateAsync(userToCreate, user.Password);
            if (isSuccess.Succeeded)
            {
                var token = _tokenGenerator.TokenGenerator(user);
                response.Success = true;
                response.Mensaje = "Usuario Creado Exitosamente";
                response.Result = token;
            }
            else
            {
                response.Mensaje = "Ocurrio Un Error";
                response.Result = isSuccess.Errors;
            }

            return Ok(response);
        }

    }
}
