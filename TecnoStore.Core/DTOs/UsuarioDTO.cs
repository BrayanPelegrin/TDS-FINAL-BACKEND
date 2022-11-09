using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TecnoStore.Core.DTOs
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
