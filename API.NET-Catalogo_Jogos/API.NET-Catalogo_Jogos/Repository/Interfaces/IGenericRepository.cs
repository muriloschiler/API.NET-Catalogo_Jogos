using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
         ValueTask<T> GetById(Guid id);
         Task<IQueryable<T>> GetByTitulo(String Titulo);
         ValueTask<IQueryable<T>> GetByKeys(Guid? categoria,string? produtora,int pagina,int quantidade);
         ValueTask<T> AddEntity(T entity);
         ValueTask UpdateEntity(T entity);

        ValueTask DeleteEntity(T entity);

    }
}