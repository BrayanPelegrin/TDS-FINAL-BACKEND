using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.Entities
{
    public class Estado: EntidadBase
    {
        //public Estado()
        //{
        //    Productos = new HashSet<Producto>();
        //    Categorias = new HashSet<Categoria>();
        //}

        public string Descripcion { get; set; }
        public Estado Estados { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}
