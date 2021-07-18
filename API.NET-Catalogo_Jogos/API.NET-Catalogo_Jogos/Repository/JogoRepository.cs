using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Jogo>> BuscarJogo(Guid? categoria, string? produtora)
        {
            try
            {
                if (produtora != null && categoria != null)
                {
                    List<Jogo> listaJogo = _context.jogos.Where(jogo=>jogo.produtora.produtora==produtora && 
                                                                jogo.id_categoria==categoria).ToList();
                    return listaJogo;
                }
                if (produtora != null )
                {
                    List<Jogo> listaJogo = _context.jogos.Where(jogo=>jogo.produtora.produtora == produtora).ToList();
                    return listaJogo;
                }
                if (categoria != null)
                {
                    List<Jogo> listaJogo = _context.jogos.Where(jogo=>jogo.id_categoria == categoria).ToList();
                    return listaJogo;
                }
                //Sem o EntityFramework.Proxie para o lazyload
                //List<Jogo> listaJogo = _context.jogos.Include(jogo => jogo.categoria).ToList();
                List<Jogo> listaJogoSemQuerry = _context.jogos.ToList();
                return listaJogoSemQuerry;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Jogo>> BuscarJogo(string titulo)
        {
            try
            {
               return _context.jogos.Where(jogo=> jogo.titulo.Contains(titulo)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Jogo> BuscarJogo(Guid idJogo)
        {
            try
            {
                Jogo jogo = _context.jogos.Where(jogo => jogo.id == idJogo).FirstOrDefault();
                return jogo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<Jogo> BuscarJogo(string titulo, Guid id_produtora, DateTime anoLancamento)
        {
            try
            {
                Jogo jogo = _context.jogos.Where(jogo =>
                                                jogo.titulo == titulo
                                                && jogo.id_produtora == id_produtora
                                                && jogo.anoLancamento == anoLancamento).FirstOrDefault();
                return jogo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task InserirJogo(Jogo jogo)
        {
            try
            {
                await _context.jogos.AddAsync(jogo);
                await _context.SaveChangesAsync();    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeletarJogo(Guid idJogo)
        {
            try
            {
                Jogo jogo = _context.jogos.Find(idJogo);
                _context.Remove(jogo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AtualizarJogo(Jogo jogoAtualizado)
        {
            try
            {
                Jogo jogo = _context.jogos.SingleOrDefault(jogo => jogo.id == jogoAtualizado.id);

                jogo.titulo = jogoAtualizado.titulo;
                jogo.produtora = jogoAtualizado.produtora;
                jogo.categoria = jogoAtualizado.categoria;
                jogo.valor = jogoAtualizado.valor;
                jogo.anoLancamento = jogoAtualizado.anoLancamento;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose() { }
    }
}
