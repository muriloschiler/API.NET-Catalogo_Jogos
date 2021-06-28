using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.ViewModels;
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

        public async Task<List<Jogo>> BuscarJogo()
        {
            List<Jogo> listaJogo =  _context.jogos.ToList();
            return listaJogo;
        }
        public async Task<Jogo> BuscarJogo(Guid idJogo)
        {
            Jogo jogo = _context.jogos.Where(jogo => jogo.id == idJogo).FirstOrDefault();
            return jogo;

        }

        public async Task InserirJogo(Jogo jogo)
        {
           _context.jogos.Add(jogo);
           await _context.SaveChangesAsync();
        }
    
       

        public void Dispose() { }

    }
}
