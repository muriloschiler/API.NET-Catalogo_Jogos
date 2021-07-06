using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Exceptions;
using API.NET_Catalogo_Jogos.InputModels;
using API.NET_Catalogo_Jogos.Services;
using API.NET_Catalogo_Jogos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Controllers
{
    
    [Route("api/v1/[controller]")]
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
            
            try
            {
                List<JogoViewModel> ListaJogoViewModels = await _jogoService.BuscarJogo();
                return Ok(ListaJogoViewModels);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }

        [HttpGet("{idJogo:Guid}")]
        public async Task<ActionResult<JogoViewModel>> BuscarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                JogoViewModel jogoViewModel = await _jogoService.BuscarJogo(idJogo);
                return Ok(jogoViewModel);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            
            try
            {
                JogoViewModel jogoViewModel = await _jogoService.InserirJogo(jogoInputModel);
                return Created(HttpContext.ToString(), jogoViewModel);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoJaCadastrado))
                       return UnprocessableEntity(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }


        [HttpDelete("{idJogo:Guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.DeletarJogo(idJogo);
                return Ok("Jogo deletado");
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeletarJogo([FromQuery] string titulo,
                                                    [FromQuery] string produtora, [FromQuery] DateTime anoLancamento)
        {
            try
            {
                await _jogoService.DeletarJogo(titulo, produtora, anoLancamento);
                return Ok("Jogo deletado");
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }

        }

        [HttpPut("{idJogo:Guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel inputJogo)
        {
            try
            {
                await _jogoService.AtualizarJogo(idJogo, inputJogo);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }

        [HttpPatch("{idJogo:Guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, 
                                                      [FromBody] JsonPatchDocument<JogoInputModel> inputUpdatesJogo )
        {
            try
            {
                await _jogoService.AtualizarJogo(idJogo, inputUpdatesJogo);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }
        
    }
}






