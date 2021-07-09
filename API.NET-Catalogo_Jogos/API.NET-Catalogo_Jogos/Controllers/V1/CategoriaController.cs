using API.NET_Catalogo_Jogos.DTO.ViewModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaService _serviceCategoria;
        public CategoriaController(ICategoriaService serviceCategoria)
        {
            _serviceCategoria = serviceCategoria;
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> BuscarCategoria()
        {
            try
            {
                List<CategoriaViewModel> listaCategoriaViewModel = await _serviceCategoria.BuscarCategoria();
                return Ok(listaCategoriaViewModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }
    }
}
