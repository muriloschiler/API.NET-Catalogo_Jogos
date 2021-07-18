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
        public Task<List<Jogo>> BuscarJogo(Guid? categoria,string? produtora,int pagina,int quantidade);
        public Task<List<Jogo>> BuscarJogo(string titulo);
        public Task<Jogo> BuscarJogo(Guid idJogo);
        public Task<Boolean> ExisteCategoria(Guid idCategoria);
        public Task<Boolean> ExisteProdutora(Guid idProdutora);

        public Task<Jogo> BuscarJogo(string titulo, Guid produtora, DateTime anoLancamento );
        public Task InserirJogo(Jogo jogo);

        public Task AtualizarJogo(Jogo jogo);

        public Task DeletarJogo(Guid idJogo);
    }
}
