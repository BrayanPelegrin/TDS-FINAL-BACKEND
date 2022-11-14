using System.Text.Json.Serialization;

namespace TecnoStore.Core.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }= String.Empty;

        [JsonIgnore]
        public virtual ICollection<ProductoDTO>? Productos { get; set; } = null!;
    }
}
