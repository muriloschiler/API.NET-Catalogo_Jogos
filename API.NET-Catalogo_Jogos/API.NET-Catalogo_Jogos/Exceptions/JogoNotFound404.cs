using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class JogoNotFound404 : Exception 
    {
        public JogoNotFound404() : base("Jogo não encontrado")
        {
        }
        public JogoNotFound404(string texto) :base(texto)
        {
        }

    }
}
