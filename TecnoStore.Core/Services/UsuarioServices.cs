using Microsoft.AspNetCore.Identity;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        // CONSTRUCTOR PARA OBTENER EL TOKEN.
        public UsuarioServices(IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> TokenGenerator(ApplicationUser Credenciales)
        {

            var token = await getToken(Credenciales);

            // RETORNANDO LAS CREDENCIALES JUNTO AL TOKEN.
            return token;
        }

        private async Task<string> getToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Token);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        
                        new Claim(ClaimTypes.NameIdentifier, user.NombreCompleto),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, roles.First())
                        
                    }),

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
