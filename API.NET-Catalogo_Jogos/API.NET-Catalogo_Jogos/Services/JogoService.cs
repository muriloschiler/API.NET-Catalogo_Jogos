﻿using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Exceptions;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.Repository;
using API.NET_Catalogo_Jogos.ViewModels;
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
       
        public async Task<List<JogoViewModel>> BuscarJogo()
        {
            List<Jogo> listaJogos = await _jogoRepository.BuscarJogo();
            if (listaJogos == null)
                throw new JogoNotFound404();

      
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
            Jogo jogo = new Jogo {
                id = new Guid(),
                titulo = inputJogoModel.titulo,
                produtora = inputJogoModel.produtora,
                categoria = inputJogoModel.categoria,
                valor = inputJogoModel.valor,
                anoLancamento = inputJogoModel.anoLancamento
            };
            await _jogoRepository.InserirJogo(jogo);

            return new JogoViewModel
            {
                id = jogo.id,
                titulo = jogo.titulo,
                produtora = jogo.produtora,
                categoria = jogo.categoria,
                valor = jogo.valor,
                anoLancamento = jogo.anoLancamento
            };
        }



        public void Dispose()
        {
            _jogoRepository.Dispose();
        }

    }
       
}
