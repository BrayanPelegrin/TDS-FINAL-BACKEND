using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TecnoStore.Core.Common;
using TecnoStore.Core.Entities.IdentityModels;
using TecnoStore.Core.Interfaces;

namespace TecnoStore.Core.Services
{
    public class UsuarioServices : ITokenManager<ApplicationUser>
    {
        private readonly AppSettings _appSettings;

        // CONSTRUCTOR PARA OBTENER EL TOKEN.
        public UsuarioServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string TokenGenerator(ApplicationUser Credenciales)
        {

            var token = getToken(Credenciales);

            // RETORNANDO LAS CREDENCIALES JUNTO AL TOKEN.
            return token;
        }

        private string getToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Token);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.NombreCompleto),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, "Todavia no eres nadie en la vida")
                    }

                    ),

                // EXPIRACION DEL TOKEN.
                Expires = DateTime.UtcNow.AddMinutes(20),

                // ENCRIPTAR INFORMACION.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }

    }
}
