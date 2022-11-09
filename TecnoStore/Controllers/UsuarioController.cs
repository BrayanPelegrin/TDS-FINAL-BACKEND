using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Interfaces;
using TecnoStore.Core.Services;

namespace TecnoStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogin<LoginDTO> _user;

        public UsuarioController(ILogin<LoginDTO> user)
        {
            _user = user;
        }

        // GET: UsuarioController

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{Login}")]
        public IActionResult Obtener(LoginDTO Log)
        {
            var Result = _user.ValidarSesion(Log);

            return Ok(Result);
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
