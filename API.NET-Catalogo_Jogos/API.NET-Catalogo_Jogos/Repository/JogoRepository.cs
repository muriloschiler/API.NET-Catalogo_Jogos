using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public class JogoRepository: IJogoRepository
    {
        public readonly ApplicationDbContext _context;
        public JogoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Jogo>> BuscarJogo()
        {
            Jogo jogo = new Jogo
            {
                id = new Guid(),
                titulo = "TituloTeste",
                produtora = "ProdutoraTeste",
                categoria = "CategoriaTeste",
                valor = 20.5,
                anoLancamento = new DateTime(2008, 5, 1, 8, 30, 52)
            };

            List<Jogo> listaJogo = new List<Jogo>();
            listaJogo.Add(jogo);
            return Task.FromResult(listaJogo);
        }
    }
}
