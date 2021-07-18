using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Exceptions
{
    public class ProdutoraNotFound : Exception
    {
        public ProdutoraNotFound() : base(" idProdutora nao encontrada"){}
    }
}
