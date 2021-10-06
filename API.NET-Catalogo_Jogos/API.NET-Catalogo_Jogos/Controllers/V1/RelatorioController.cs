using API.NET_Catalogo_Jogos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RelatorioController : Controller
    {
        readonly ReportService _reportService;

        public RelatorioController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]    
        public async Task<IActionResult> GetReport([FromRoute] string typeReport )
        {
            _reportService.BuildReport(typeReport);

            return Ok(typeReport);
            
        }
    }
}
