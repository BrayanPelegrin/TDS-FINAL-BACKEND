using System.Text.Json.Serialization;

namespace TecnoStore.Core.DTOs
{
    public class UsuarioDTO
    {
        [JsonIgnore]
        public string? Id { get; set; } = null;
        public string UserName { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
