using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.DTOs
{
    public class CategoriaDTO
    {
        public string Descripcion { get; set; }= String.Empty;

        public virtual ICollection<ProductoDTO> Productos { get; set; }
    }
}
