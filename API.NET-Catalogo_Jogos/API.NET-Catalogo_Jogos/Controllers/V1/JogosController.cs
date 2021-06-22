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
    public class JogosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> BuscarJogo()
        {
            return Ok("Lista Jogos");
        }

        [HttpGet("{idJogo:Guid}")]
        public async Task<ActionResult<JogoViewModel>> BuscarJogo([FromRoute] Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogo)
        {
            return Ok(jogo);
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






