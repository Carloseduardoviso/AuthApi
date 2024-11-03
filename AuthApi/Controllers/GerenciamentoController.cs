using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Models;
using Bussines.Data.Requests.Gerenciamento.Auth;
using Bussines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Bussines.Data.Requests.Searchs.Paginations;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]/")]
    public class GerenciamentoController : Controller
    {
        private readonly IGerenciamentoService _gerenciamentoService;

        public GerenciamentoController(IGerenciamentoService gerenciamentoService)
        {
            _gerenciamentoService = gerenciamentoService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Entrar([FromBody] GerenciamentoAuthResquest gerenciamentoAuthResquest)
        {
            try
            {
                var consumidor = await _gerenciamentoService.EntrarAsync(gerenciamentoAuthResquest);

                return Json(consumidor);
            }
            catch (Exception ex)
            {
                return Json(new Result<ConsumidorVm>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterSistemaPaginado([FromBody] SearchSistemaPagiantionRequest searchSistemaPagiantionRequest)
        {
            try
            {
                var sistemaPaginados = await _gerenciamentoService.ObterSistemaPaginado(searchSistemaPagiantionRequest);

                return Json(sistemaPaginados);
            }
            catch (Exception ex)
            {
                return Json(new Result<SistemaVm>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
    }
}
