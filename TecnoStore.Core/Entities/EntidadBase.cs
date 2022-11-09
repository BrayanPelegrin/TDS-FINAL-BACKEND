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
        public int EstadoId { get; set; } = (int)Enums.Estados.Activo;
        public DateTime FechaCreo { get; set;} = DateTime.Now;
        public string UsuarioCreo { get; set; }

        

    }
}
