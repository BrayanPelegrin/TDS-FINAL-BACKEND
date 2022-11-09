using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.Entities
{
    public class Producto: EntidadBase
    {
        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        

        //Propiedades De Navegacion
        public virtual Categoria Categoria { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
