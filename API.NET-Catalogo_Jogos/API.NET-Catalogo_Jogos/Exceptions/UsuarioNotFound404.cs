using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class UsuarioNotFound404 : Exception
    {
        public UsuarioNotFound404() : base("Usuario nao encontrado") { }
    }
}
