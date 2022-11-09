using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoStore.Core.DTOs;

namespace TecnoStore.Core.Interfaces
{
    public interface ILogin<T>
    {
        public T ValidarSesion(T t);

    }
}
