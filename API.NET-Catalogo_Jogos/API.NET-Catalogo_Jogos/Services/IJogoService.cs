using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
   public interface IJogoService
    {
        public Task<List<JogoViewModel>> BuscarJogo();
        public Task<JogoViewModel> InserirJogo(JogoInputModel jogo);
    }
}
