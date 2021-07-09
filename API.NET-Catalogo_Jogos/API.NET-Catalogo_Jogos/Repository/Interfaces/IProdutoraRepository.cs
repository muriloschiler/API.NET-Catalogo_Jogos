using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public interface IProdutoraRepository
    {
        public Task<List<Produtora>> BuscarProdutora(); 
    }
}
