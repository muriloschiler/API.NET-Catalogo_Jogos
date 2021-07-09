using API.NET_Catalogo_Jogos.DTO.ViewModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<List<CategoriaViewModel>> BuscarCategoria()
        {
            List<Categoria> listaCategoria = await _categoriaRepository.BuscarCategoria();
            return listaCategoria.Select(categoria => new CategoriaViewModel
            {
                id = categoria.id,
                descricao = categoria.descricao
            }).ToList();

            
        }
        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }
    }
}
