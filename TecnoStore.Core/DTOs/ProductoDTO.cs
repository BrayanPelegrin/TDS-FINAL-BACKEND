using System.Text.Json.Serialization;

namespace TecnoStore.Core.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        //DTO DE NAVEGACION
        [JsonIgnore]
        public virtual CategoriaDTO? Categoria { get; set; } = null!;
    }
}
