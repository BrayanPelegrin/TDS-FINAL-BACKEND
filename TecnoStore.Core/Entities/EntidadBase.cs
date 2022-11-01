using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.Entities
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaCreo { get; set;}
        public string UsuarioCreo { get; set; }

        

    }
}
