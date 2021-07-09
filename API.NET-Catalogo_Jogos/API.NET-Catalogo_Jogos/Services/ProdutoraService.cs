using API.NET_Catalogo_Jogos.DTO.ViewModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public class ProdutoraService : IProdutoraService
    {
        public readonly IProdutoraRepository _produtoraRepository;
        public ProdutoraService(IProdutoraRepository produtoraRepository)
        {
            _produtoraRepository = produtoraRepository;
        }

        public async Task<List<ProdutoraViewModel>> BuscarProdutora()
        {
            List<Produtora> listaProdutoras = await _produtoraRepository.BuscarProdutora();
            return listaProdutoras.Select(produtora => new ProdutoraViewModel
            {
                id = produtora.id,
                produtora = produtora.produtora
            }).ToList();
            
        }
        public void Dispose()
        {
            _produtoraRepository.Dispose();
        }
    }
}
