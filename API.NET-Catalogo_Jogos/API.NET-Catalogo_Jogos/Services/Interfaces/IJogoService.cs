using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
   public interface IJogoService : IDisposable
    {
        public Task<List<JogoViewModel>> BuscarJogo(Guid? categoria, string? produtora,int pagina, int quantidade);
        public Task<List<JogoViewModel>> BuscarJogo(string titulo);
        public Task<JogoViewModel> BuscarJogo(Guid idJogo);
        public Task<InsertJogoViewModel> InserirJogo(JogoInputModel jogo);

        public Task DeletarJogo(Guid idJogo);
        public Task DeletarJogo(String titulo, Guid id_produtora,DateTime anoLancamento);
        public Task AtualizarJogo(Guid idJogo,JogoInputModel inputJogo);

        public Task AtualizarJogo(Guid idJogo, JsonPatchDocument<JogoInputModel> inputUpdatesJogo);
    }
}
