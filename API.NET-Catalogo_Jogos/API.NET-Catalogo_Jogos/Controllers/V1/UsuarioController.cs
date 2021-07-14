using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Exceptions;
using API.NET_Catalogo_Jogos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace API.NET_Catalogo_Jogos.Controllers.V1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> FazerVenda(VendaInputModel vendaInputModel)
        {
            try
            {
                await _usuarioService.FazerVenda(vendaInputModel);
                return Ok("Compra realizada com sucesso!");
            }
            catch (Exception ex)
            {
                if(ex.GetType() == typeof(UsuarioNotFound404)
                   || ex.GetType() == typeof(JogoNotFound404))
                {
                    return NotFound(ex.Message);
                }

                return Problem(ex.Message);
            }
        }
     
    }
}
