using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.Entities
{
    public  class Carrito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }

        //Objeto de Navegacion
        public Producto Producto { get; set; }
       

    }
}
