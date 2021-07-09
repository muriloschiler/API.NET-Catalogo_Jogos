using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public class ProdutoraRepository : IProdutoraRepository
    {
        public ApplicationDbContext _context;

        public ProdutoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Produtora>> BuscarProdutora()
        {
            try 
            {
                return _context.produtoras.ToList();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }

        }
    }
}
