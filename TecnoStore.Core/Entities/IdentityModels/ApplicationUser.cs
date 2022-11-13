using Microsoft.AspNetCore.Identity;

namespace TecnoStore.Core.Entities.IdentityModels
{
    public class ApplicationUser: IdentityUser
    {
        public string NombreCompleto { get; set; } = string.Empty;
    }
}
