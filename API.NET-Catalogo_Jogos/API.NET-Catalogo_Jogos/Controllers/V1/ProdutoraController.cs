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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoraController : ControllerBase
    {
        public readonly IProdutoraService _produtoraService;

        public ProdutoraController(IProdutoraService produtoraService)
        {
            _produtoraService = produtoraService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produtora>>> BuscarProdutora()
        {
            try
            {
                List<ProdutoraViewModel> listaProdutora = await _produtoraService.BuscarProdutora();
                return Ok(listaProdutora);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }


        }

    }
}