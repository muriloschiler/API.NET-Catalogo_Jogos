using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class UsuarioJaCadastrado:Exception
    {
        public UsuarioJaCadastrado() : base("Usuario ja cadastrado") { }
    }
}
