using API.NET_Catalogo_Jogos.DTO.ViewModels;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public interface ICategoriaService: IDisposable
    {
        public Task<List<CategoriaViewModel>> BuscarCategoria();
    }
}
