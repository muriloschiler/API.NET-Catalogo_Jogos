using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Exceptions;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.Repository;
using API.NET_Catalogo_Jogos.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public class JogoService: IJogoService
    {

        public readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
       
        public async Task<List<JogoViewModel>> BuscarJogo(Guid? categoria, string? produtora)
        {
            List<Jogo> listaJogos = await _jogoRepository.BuscarJogo(categoria, produtora);
            if (listaJogos.Count == 0)
                throw new JogoNotFound404("Nenhum jogo encontrdo");

      
            return listaJogos.Select(jogo => new JogoViewModel
            {
                id = jogo.id,
                titulo = jogo.titulo,
                produtora = jogo.produtora,
                categoria = jogo.categoria,
                valor = jogo.valor,
                anoLancamento = jogo.anoLancamento
            }).ToList() ;
        }

        public async Task<JogoViewModel> BuscarJogo(Guid idJogo) 
        {
            Jogo jogo = await _jogoRepository.BuscarJogo(idJogo);

            if (jogo == null)
                throw new JogoNotFound404();

            JogoViewModel jogoViewModel = new JogoViewModel
            {
                id = jogo.id,
                titulo = jogo.titulo,
                produtora = jogo.produtora,
                categoria = jogo.categoria,
                valor = jogo.valor,
                anoLancamento = jogo.anoLancamento
            };

            return jogoViewModel;
        }

        public async Task<JogoViewModel> InserirJogo(JogoInputModel inputJogoModel)
        {
            
            Jogo jogo = await _jogoRepository.BuscarJogo(inputJogoModel.titulo, 
                                                         inputJogoModel.id_produtora, 
                                                         inputJogoModel.anoLancamento);

            if (jogo != null)
                throw new JogoJaCadastrado();


            jogo = new Jogo {
                id = new Guid(),
                titulo = inputJogoModel.titulo,
                id_produtora = inputJogoModel.id_produtora,
                id_categoria = inputJogoModel.id_categoria,
                valor = inputJogoModel.valor,
                anoLancamento = inputJogoModel.anoLancamento
            };
            //Jogo recebido apos a instanciacao dos proxys de Jogo(Categoria e Produtora)
            await _jogoRepository.InserirJogo(jogo);
            Jogo jogoComProxys = await _jogoRepository.BuscarJogo(jogo.id);
            
            return new JogoViewModel
            {
                id = jogoComProxys.id,
                titulo = jogoComProxys.titulo,
                produtora = jogoComProxys.produtora,
                categoria = jogoComProxys.categoria,
                valor = jogoComProxys.valor,
                anoLancamento = jogoComProxys.anoLancamento
            };
        }

        public async Task DeletarJogo(Guid idJogo)
        {
            Jogo jogo = await _jogoRepository.BuscarJogo(idJogo);
            if (jogo == null)
                throw new JogoNotFound404() ;

            await _jogoRepository.DeletarJogo(idJogo);
            
        }
        public async Task DeletarJogo(string titulo, Guid id_produtora, DateTime anoLancamento)
        {
            Jogo jogo = await _jogoRepository.BuscarJogo(titulo,id_produtora,anoLancamento);
            if (jogo == null)
                throw new JogoNotFound404();

            await _jogoRepository.DeletarJogo(jogo.id);
        }

        public async Task AtualizarJogo(Guid idJogo, JogoInputModel inputJogo)
        {
            Jogo jogoAtualizado = await _jogoRepository.BuscarJogo(idJogo);
            if(jogoAtualizado == null)
                throw new JogoNotFound404();

            jogoAtualizado = new Jogo
            {
                id = idJogo,
                titulo = inputJogo.titulo,
                id_produtora = inputJogo.id_produtora,
                id_categoria = inputJogo.id_categoria,
                valor = inputJogo.valor,
                anoLancamento = inputJogo.anoLancamento
            };

            await _jogoRepository.AtualizarJogo(jogoAtualizado);
        }

        public async Task AtualizarJogo(Guid idJogo, JsonPatchDocument<JogoInputModel> inputUpdatesJogo)
        {
            Jogo jogoAtualizado = await _jogoRepository.BuscarJogo(idJogo);
            if (jogoAtualizado == null)
                throw new JogoNotFound404();


            //PATCH com "op" = "replace"
            //É resgatado o valor antigo de jogo
            JogoInputModel inputJogo = new JogoInputModel {
                titulo = jogoAtualizado.titulo,
                id_produtora = jogoAtualizado.id_produtora,
                id_categoria = jogoAtualizado.id_categoria,
                valor = jogoAtualizado.valor,
                anoLancamento = jogoAtualizado.anoLancamento
            };
            //É realizado as modificacoes de replace especificadas no patch
            inputUpdatesJogo.ApplyTo(inputJogo);

            //É criado entao um jogo com essas modificacoes
            jogoAtualizado = new Jogo
            {
                id = idJogo,
                titulo = inputJogo.titulo,
                id_produtora = inputJogo.id_produtora,
                id_categoria = inputJogo.id_categoria,
                valor = inputJogo.valor,
                anoLancamento = inputJogo.anoLancamento
             };
            
            await _jogoRepository.AtualizarJogo(jogoAtualizado);
        }

        public void Dispose()
        {
            _jogoRepository.Dispose();
        }

        
    }
       
}
