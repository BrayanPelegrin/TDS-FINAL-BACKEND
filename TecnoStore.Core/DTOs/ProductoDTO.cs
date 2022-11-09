namespace TecnoStore.Core.DTOs
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        //DTO DE NAVEGACION

        public virtual CategoriaDTO Categoria { get; set; }
    }
}
