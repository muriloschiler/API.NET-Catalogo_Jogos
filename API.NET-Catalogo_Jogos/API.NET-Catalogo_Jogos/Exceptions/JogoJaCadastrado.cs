using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class JogoJaCadastrado: Exception
    {
        public JogoJaCadastrado():base("Jogo ja cadastrado") { }
    }
}
