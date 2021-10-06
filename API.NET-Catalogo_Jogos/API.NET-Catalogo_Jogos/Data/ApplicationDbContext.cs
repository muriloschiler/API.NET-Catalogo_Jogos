using Microsoft.EntityFrameworkCore;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace API.NET_Catalogo_Jogos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public readonly IConfiguration _config ;

        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Jogo> jogos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produtora> produtoras { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Venda> vendas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:MySQL"])
                .UseLazyLoadingProxies();
        }
    }
}
