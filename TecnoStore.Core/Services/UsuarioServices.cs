using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TecnoStore.Core.Common;
using TecnoStore.Core.DTOs;
using TecnoStore.Core.Interfaces;

namespace TecnoStore.Core.Services
{
    public class UsuarioServices : ILogin<LoginDTO>
    {
        // LISTA TEMPORAL DE USUARIOS.
        List<UsuarioDTO> user = new List<UsuarioDTO>();

        private readonly AppSettings _appSettings;

        // CONSTRUCTOR PARA OBTENER EL TOKEN.
        public UsuarioServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        void Insertar()
        {

            user.Add(new UsuarioDTO()
            {
                ID = 1,
                Name = "Miguel",
                Correo = "miguelangelcruz200217@gmail.com",
                Password = "miguel2002"
            });

        }

        public LoginDTO ValidarSesion(LoginDTO Credenciales)
        {
            // LLAMANDO EL METODO PARA INSERTAR DATOS EN LA LISTA.
            Insertar();

            var usuario = user.Where(d => d.Correo == Credenciales.Correo 
                          && d.Password == Credenciales.Password).FirstOrDefault();

            if (usuario == null)
            {
                return null;
            }

            Credenciales.Token = getToken(usuario);

            // RETORNANDO LAS CREDENCIALES JUNTO AL TOKEN.
            return Credenciales;
        }

        private string getToken(UsuarioDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Token);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        new Claim(ClaimTypes.Email, user.Correo)
                    }

                    ),

                // EXPIRACION DEL TOKEN.
                Expires = DateTime.UtcNow.AddDays(60),
                
                // ENCRIPTAR INFORMACION.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }

    }
}
