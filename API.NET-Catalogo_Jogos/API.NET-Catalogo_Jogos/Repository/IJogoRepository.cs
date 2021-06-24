using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public interface IJogoRepository
    {
        public Task<List<Jogo>> BuscarJogo();
        public Task InserirJogo(Jogo jogo);
    }
}
