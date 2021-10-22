using System;
using System.Linq;
using System.Threading.Tasks;
using API.NET_Catalogo_Jogos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.NET_Catalogo_Jogos.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly DbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DbContext appdbContext)
        {
            _appDbContext = appdbContext;
            
        }
        public async ValueTask<T> AddEntity(T entity)
        {
            var entityEntry = await _appDbContext.AddAsync(entity);
            return entityEntry.Entity;
        }

        public ValueTask DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IQueryable<T>> GetByKeys(Guid? categoria, string produtora, int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetByTitulo(string Titulo)
        {
            throw new NotImplementedException();
        }

        public ValueTask UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}