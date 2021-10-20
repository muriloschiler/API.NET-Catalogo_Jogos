using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public ApplicationDbContext _context { get; set; }

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> BuscarCategoria()
        {
            
            return _context.categorias.ToList();
        }
        
        public void Dispose() { }
    }
}
