using API.NET_Catalogo_Jogos.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public interface IProdutoraService
    {
        public Task<List<ProdutoraViewModel>> BuscarProdutora();
        
    }
}
