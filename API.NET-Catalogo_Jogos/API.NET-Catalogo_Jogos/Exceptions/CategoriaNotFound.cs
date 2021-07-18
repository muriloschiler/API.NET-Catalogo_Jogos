using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class CategoriaNotFound : Exception
    {
        public CategoriaNotFound() : base("idCategoria nao encontrado") { }
    }
}
