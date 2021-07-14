using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Exceptions;
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
        public readonly IUsuarioRepository _usuarioRepository;
        public readonly IJogoRepository _jogoRepository;

        public UsuarioService(IVendaRepository vendaRepository, IUsuarioRepository usuarioRepository, IJogoRepository jogoRepository)
        {
            _vendaRepository = vendaRepository;
            _usuarioRepository = usuarioRepository;
            _jogoRepository = jogoRepository;

        }
        public async Task FazerVenda(VendaInputModel vendaInputModel)
        {
            Usuario usuario = await _usuarioRepository.BuscarUsuario(vendaInputModel.id_usuario);
            Jogo jogo = await _jogoRepository.BuscarJogo(vendaInputModel.id_Jogo);

            if (usuario == null)
                throw new UsuarioNotFound404();
            if (jogo == null)
                throw new JogoNotFound404();


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
