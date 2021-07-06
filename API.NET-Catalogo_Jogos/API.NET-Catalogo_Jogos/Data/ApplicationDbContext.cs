using Microsoft.EntityFrameworkCore;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Jogo> jogos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost\SQLEXPRESS;Database=API-Catalogos_Jogos;Trusted_Connection=True");
        }
    }
}
