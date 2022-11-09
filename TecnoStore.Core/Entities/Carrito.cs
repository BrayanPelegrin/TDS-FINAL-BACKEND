using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.Entities
{
    public  class Carrito: EntidadBase
    {
       
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }

        //Objeto de Navegacion
        public virtual Producto Producto { get; set; }
       

    }
}
