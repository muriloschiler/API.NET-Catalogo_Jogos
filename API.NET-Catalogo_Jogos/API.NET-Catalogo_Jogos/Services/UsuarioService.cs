using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IVendaRepository _vendaRepository;

        public UsuarioService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        public async Task FazerVenda(VendaInputModel vendaInputModel)
        {
            Venda venda = new Venda
            {
                id_usuario = vendaInputModel.id_usuario,
                id_jogo = vendaInputModel.id_Jogo,
                dataVenda = vendaInputModel.dataVenda,
                valorTotal = vendaInputModel.valorTotal
            };
            await _vendaRepository.FazerVenda(venda);    
        }
        public void Dispose()
        {
            _vendaRepository.Dispose();
        }
    }
}
