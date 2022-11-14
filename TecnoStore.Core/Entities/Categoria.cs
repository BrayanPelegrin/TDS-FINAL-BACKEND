﻿namespace TecnoStore.Core.Entities
{
    public class Categoria: EntidadBase
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }


        public virtual ICollection<Producto> Productos { get; set; }
    }
}
