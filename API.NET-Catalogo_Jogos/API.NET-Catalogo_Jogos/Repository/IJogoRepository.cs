using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public interface IJogoRepository : IDisposable
    {
        public Task<List<Jogo>> BuscarJogo();
        public Task<Jogo> BuscarJogo(Guid idJogo);

        public Task<Jogo> BuscarJogo(string titulo, string produtora, DateTime anoLancamento );
        public Task InserirJogo(Jogo jogo);

        public Task AtualizarJogo(Jogo jogo);

        public Task DeletarJogo(Guid idJogo);
    }
}
