using AutoMapper;
using Bussines.Data.Entityes;
using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Requests.Paginations;
using Bussines.Data.Requests.Searchs;
using Bussines.Data.Requests.Searchs.Paginations;
using Bussines.Data.Requests.Usuario;
using Bussines.Data.Requests.UsuarioSistema;
using Bussines.Data.Responses;
using Bussines.Helpers.Filters;
using Bussines.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]/")]
    public class UsuarioSistemaController : Controller
    {
        private readonly IUsuarioSistemaService _usuarioSistemaService;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;

        public UsuarioSistemaController(
            IUsuarioSistemaService usuarioSistemaService,
            IUnitOfWorkService unitOfWorkService,
            IMapper mapper
        )
        {
            _usuarioSistemaService = usuarioSistemaService;
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }

        #region GET

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterUsuarioPaginado([FromQuery] SearchUsuarioSistemaPaginationRequest searchUsuarioSistemaPaginationRequest)
        {
            try
            {
                Expression<Func<UsuarioSistema, bool>> expression = x => true;

                if (searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest is not null)
                {
                    if (searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest.UsuarioId is not null && !searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest.UsuarioId.Equals(Guid.Empty))
                    {
                        expression = UsuarioSistemaFilter.ConUsuario(new UsuarioSistemaVm()
                        {
                            UsuarioId = (Guid)searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest.UsuarioId,
                            SistemaId = (Guid)searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest.UsuarioSistemaId,
                            Sistema = new SistemaVm()
                            {
                                ControllerProtocoloHttp = searchUsuarioSistemaPaginationRequest?.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.ControllerProtocoloHttp,
                                UrlController = searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlController,
                                UrlAction = searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlAction
                            }
                        });
                    }
                    else
                    {
                        expression = UsuarioSistemaFilter.ConUsuario(new UsuarioSistemaVm()
                        {
                            SistemaId = (Guid)searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest.UsuarioSistemaId,
                            Sistema = new SistemaVm()
                            {
                                ControllerProtocoloHttp = searchUsuarioSistemaPaginationRequest?.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.ControllerProtocoloHttp,
                                UrlController = searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlController,
                                UrlAction = searchUsuarioSistemaPaginationRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlAction
                            }
                        });
                    }
                }

                var expressionUsuarioSistemaMapping = _mapper.Map<Expression<Func<UsuarioSistemaVm, bool>>>(expression);

                var usuarioSistemasPaginados = await _usuarioSistemaService.GetAllUsuarioPaginationAsync(expressionUsuarioSistemaMapping);

                var resultado = new ResultDataResponse<Pagination<UsuarioSistemaVm>>(
                       false,
                       200,
                       usuarioSistemasPaginados,
                       "Sucesso ao obter a usuários do sistema páginada"
                    );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<Pagination<UsuarioSistemaVm>>(
                       false,
                       statusCode,
                       null,
                       ex.Message
                    );

                return Json(resultado);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterUsuario([FromQuery] SearchUsuarioSistemaRequest searchUsuarioSistemaRequest)
        {
            try
            {
                Expression<Func<UsuarioSistema, bool>> expression = x => true;

                if (searchUsuarioSistemaRequest.UsuarioSistemaRequest is not null)
                {
                    if (searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioId is not null && !searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioId.Equals(Guid.Empty))
                    {
                        expression = UsuarioSistemaFilter.ConUsuario(new UsuarioSistemaVm()
                        {
                            UsuarioId = (Guid)searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioId,
                            SistemaId = (Guid)searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioSistemaId,
                            Sistema = new SistemaVm()
                            {
                                ControllerProtocoloHttp = searchUsuarioSistemaRequest?.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.ControllerProtocoloHttp,
                                UrlController = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlController,
                                UrlAction = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlAction
                            }
                        });
                    }
                    else
                    {
                        expression = UsuarioSistemaFilter.ConUsuario(new UsuarioSistemaVm()
                        {
                            SistemaId = (Guid)searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioSistemaId,
                            Sistema = new SistemaVm()
                            {
                                ControllerProtocoloHttp = searchUsuarioSistemaRequest?.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.ControllerProtocoloHttp,
                                UrlController = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlController,
                                UrlAction = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlAction
                            }
                        });
                    }
                }

                var expressionUsuarioSistemaMapping = _mapper.Map<Expression<Func<UsuarioSistemaVm, bool>>>(expression);

                var usuarioSistemaPaginados = await _usuarioSistemaService.GetUsuarioAsync(expressionUsuarioSistemaMapping);

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                       false,
                       200,
                       usuarioSistemaPaginados,
                       "Sucesso ao obter a usuário do sistema"
                    );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                       false,
                       statusCode,
                       null,
                       ex.Message
                    );

                return Json(resultado);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterUsuarioSistemas([FromQuery] SearchUsuarioSistemaRequest searchUsuarioSistemaRequest)
        {
            try
            {
                Expression<Func<UsuarioSistema, bool>> expression = x => true;

                if (searchUsuarioSistemaRequest.UsuarioSistemaRequest is not null)
                {
                    if (searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioId is not null && !searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioId.Equals(Guid.Empty))
                    {
                        expression = UsuarioSistemaFilter.ConUsuario(new UsuarioSistemaVm()
                        {
                            UsuarioId = (Guid)searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioId,
                            SistemaId = (Guid)searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioSistemaId,
                            Sistema = new SistemaVm()
                            {
                                ControllerProtocoloHttp = searchUsuarioSistemaRequest?.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.ControllerProtocoloHttp,
                                UrlController = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlController,
                                UrlAction = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlAction
                            }
                        });
                    }
                    else
                    {
                        expression = UsuarioSistemaFilter.ConUsuario(new UsuarioSistemaVm()
                        {
                            SistemaId = (Guid)searchUsuarioSistemaRequest.UsuarioSistemaRequest.UsuarioSistemaId,
                            Sistema = new SistemaVm()
                            {
                                ControllerProtocoloHttp = searchUsuarioSistemaRequest?.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.ControllerProtocoloHttp,
                                UrlController = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlController,
                                UrlAction = searchUsuarioSistemaRequest.UsuarioSistemaRequest?.UsuarioSistema?.Sistema?.UrlAction
                            }
                        });
                    }
                }

                var expressionUsuarioSistemaMapping = _mapper.Map<Expression<Func<UsuarioSistemaVm, bool>>>(expression);

                var usaurioSistemas = await _usuarioSistemaService.GetUsuariosAsync(expressionUsuarioSistemaMapping);

                var resultado = new ResultDataResponse<IEnumerable<UsuarioSistemaVm>>(
                       false,
                       200,
                       usaurioSistemas,
                       "Sucesso ao obter os usuários do sistema"
                    );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                       false,
                       statusCode,
                       null,
                       ex.Message
                    );

                return Json(resultado);
            }
        }

        #endregion GET

        #region POST

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarUsuarioSistema([FromBody] CriarUsuarioSistemaRequest criarUsuarioSistemaRequest)
        {
            try
            {
                var usuarioSistemaAdicionar = await _usuarioSistemaService.AddUsuarioAsync(criarUsuarioSistemaRequest);

                await _unitOfWorkService.CommitAsync();

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                                false,
                                200,
                                usuarioSistemaAdicionar,
                                "Sucesso ao adicionar a usuário do sistema"
                            );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                        false,
                        statusCode,
                        null,
                        ex.Message
                    );

                return Json(resultado);
            }
        }

        #endregion POST

        #region PUT

        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarUsuario([FromBody] EditeUsuarioSistemaRequest editeUsuarioRequest)
        {
            try
            {
                var usuarioSistemaEditar = await _usuarioSistemaService.UpdateUsuario(editeUsuarioRequest);

                await _unitOfWorkService.CommitAsync();

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                                false,
                                200,
                                usuarioSistemaEditar,
                                "Sucesso ao editar a ususário do sistema"
                            );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                        false,
                        statusCode,
                        null,
                        ex.Message
                    );

                return Json(resultado);
            }
        }

        #endregion PUT

        #region DELETE

        [HttpDelete]
        [Route("[action]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExcluirUsuario([FromBody] RemoverUsuarioSistemaRequest removerUsuarioRequest)
        {
            try
            {
                var usuarioSistemaRemover = await _usuarioSistemaService.RemoveUsuario(removerUsuarioRequest);

                await _unitOfWorkService.CommitAsync();

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                                false,
                                200,
                                usuarioSistemaRemover,
                                "Sucesso ao excluír a ususário do sistema"
                            );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioSistemaVm>(
                        false,
                        statusCode,
                        null,
                        ex.Message
                    );

                return Json(resultado);
            }
        }

        #endregion DELETE
    }
}
