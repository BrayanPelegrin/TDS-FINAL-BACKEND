namespace TecnoStore.Core.Entities
{
    public class Estado: EntidadBase
    {

        public string Descripcion { get; set; }
        public Estado Estados { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}
