using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class UsuarioNotFound : Exception
    {
        public UsuarioNotFound() : base("Usuario nao encontrado") { }
    }
}
