using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.Services;
using API.NET_Catalogo_Jogos.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        public readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> BuscarJogo()
        {
            List<JogoViewModel> ListaJogoViewModels = await _jogoService.BuscarJogo();
            return Ok(ListaJogoViewModels);
        }


        [HttpGet("{idJogo:Guid}")]
        public async Task<ActionResult<JogoViewModel>> BuscarJogo([FromRoute] Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            JogoViewModel jogoViewModel = await _jogoService.InserirJogo(jogoInputModel);
            return Ok(jogoViewModel);
        }

        [HttpPut("{idJogo:Guid}")]
        public async Task<ActionResult<JogoViewModel>> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogo)
        {
            return Ok(jogo);

        }
            

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")] 
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            return Ok();
        }
        
        [HttpDelete("{idJogo:Guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idJogo)
        {
            return Ok();
        }
    }
}






