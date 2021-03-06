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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 
namespace API.NET_Catalogo_Jogos.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class JogoController : ControllerBase
    {
        public readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }


        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> BuscarJogo([FromQuery] Guid? categoria , [FromQuery] string ? produtora,
                                                                        [FromQuery, Range(1, int.MaxValue)] int pagina = 1, 
                                                                        [FromQuery, Range(1, 50)] int quantidade = 5)                                                    
        {
            try
            {
                List<JogoViewModel> ListaJogoViewModels = await _jogoService.BuscarJogo(categoria, produtora,pagina,quantidade);
                return Ok(ListaJogoViewModels);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoNotFound404))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }
        
        [Route("Titulo")]
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> BuscarJogo([FromQuery] string titulo)
        {
            try
            {
                List<JogoViewModel> listaJogos = await _jogoService.BuscarJogo(titulo);
                return Ok(listaJogos);
            }
            catch(Exception ex)
            {
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
        public async Task<ActionResult<InsertJogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            
            try
            {
                InsertJogoViewModel insertJogoViewModel = await _jogoService.InserirJogo(jogoInputModel);
                return Created(HttpContext.ToString(), insertJogoViewModel);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(JogoJaCadastrado))
                       return UnprocessableEntity(ex.Message);
                if (ex.GetType() == typeof(ProdutoraNotFound))
                    return NotFound(ex.Message);
                if (ex.GetType() == typeof(CategoriaNotFound))
                    return NotFound(ex.Message);

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
                                                    [FromQuery] Guid id_produtora, [FromQuery] DateTime anoLancamento)
        {
            try
            {
                await _jogoService.DeletarJogo(titulo, id_produtora, anoLancamento);
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






