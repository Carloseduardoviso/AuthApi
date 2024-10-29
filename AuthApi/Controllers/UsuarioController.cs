using AutoMapper;
using Bussines.Data.Entityes;
using Bussines.Data.Models;
using Bussines.Data.Requests.Paginations;
using Bussines.Data.Requests.Searchs;
using Bussines.Data.Requests.Usuario;
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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;

        public UsuarioController(
            IUsuarioService usuarioService,
            IUnitOfWorkService unitOfWorkService,
            IMapper mapper
        )
        {
            _usuarioService = usuarioService;
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        } 

        #region GET

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterUsuarioPaginado([FromQuery] SearchUsuarioPaginationRequest searchUsuarioPaginationRequest)
        {
            try
            {
                Expression<Func<Usuario, bool>> expression = x => true;

                if (searchUsuarioPaginationRequest.UsuarioRequest is not null)
                {
                    if (searchUsuarioPaginationRequest.UsuarioRequest.UsuarioId is not null && !searchUsuarioPaginationRequest.UsuarioRequest.UsuarioId.Equals(Guid.Empty))
                    {
                        expression = AuthFilter.ConUsuario(new UsuarioVm()
                        {
                            UsuarioId = (Guid)searchUsuarioPaginationRequest.UsuarioRequest.UsuarioId,
                            NomeCompleto = searchUsuarioPaginationRequest.UsuarioRequest.NomeCompleto,
                            Telefone = searchUsuarioPaginationRequest.UsuarioRequest.Telefone,
                            CPF = searchUsuarioPaginationRequest.UsuarioRequest.CPF,
                            Email = searchUsuarioPaginationRequest.UsuarioRequest.Email,
                            Senha = searchUsuarioPaginationRequest.UsuarioRequest.Senha,
                        });
                    }
                    else
                    {
                        expression = AuthFilter.ConUsuario(new UsuarioVm()
                        {
                            NomeCompleto = searchUsuarioPaginationRequest.UsuarioRequest.NomeCompleto,
                            Telefone = searchUsuarioPaginationRequest.UsuarioRequest.Telefone,
                            CPF = searchUsuarioPaginationRequest.UsuarioRequest.CPF,
                            Email = searchUsuarioPaginationRequest.UsuarioRequest.Email,
                            Senha = searchUsuarioPaginationRequest.UsuarioRequest.Senha,
                        });
                    }
                }

                var expressionPermissaoMapping = _mapper.Map<Expression<Func<UsuarioVm, bool>>>(expression);

                var usuariosPaginados = await _usuarioService.GetAllUsuarioPaginationAsync(expressionPermissaoMapping);

                var resultado = new ResultDataResponse<Pagination<UsuarioVm>>(
                       false,
                       200,
                       usuariosPaginados,
                       "Sucesso ao obter a permissão páginada"
                    );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<Pagination<UsuarioVm>>(
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
        public async Task<IActionResult> ObterUsuario([FromQuery] SearchUsuarioRequest searchUsuarioRequest)
        {
            try
            {
                Expression<Func<Usuario, bool>> expression = x => true;

                if (searchUsuarioRequest.UsuarioRequest is not null)
                {
                    if (searchUsuarioRequest.UsuarioRequest.UsuarioId is not null && !searchUsuarioRequest.UsuarioRequest.UsuarioId.Equals(Guid.Empty))
                    {
                        expression = AuthFilter.ConUsuario(new UsuarioVm()
                        {
                            UsuarioId = (Guid)searchUsuarioRequest.UsuarioRequest.UsuarioId,
                            NomeCompleto = searchUsuarioRequest.UsuarioRequest.NomeCompleto,
                            Telefone = searchUsuarioRequest.UsuarioRequest.Telefone,
                            CPF = searchUsuarioRequest.UsuarioRequest.CPF,
                            Email = searchUsuarioRequest.UsuarioRequest.Email,
                            Senha = searchUsuarioRequest.UsuarioRequest.Senha,
                        });
                    }
                    else
                    {
                        expression = AuthFilter.ConUsuario(new UsuarioVm()
                        {
                            NomeCompleto = searchUsuarioRequest.UsuarioRequest.NomeCompleto,
                            Telefone = searchUsuarioRequest.UsuarioRequest.Telefone,
                            CPF = searchUsuarioRequest.UsuarioRequest.CPF,
                            Email = searchUsuarioRequest.UsuarioRequest.Email,
                            Senha = searchUsuarioRequest.UsuarioRequest.Senha,
                        });
                    }
                }

                var expressionPermissaoMapping = _mapper.Map<Expression<Func<UsuarioVm, bool>>>(expression);

                var usuarioPaginados = await _usuarioService.GetUsuarioAsync(expressionPermissaoMapping);

                var resultado = new ResultDataResponse<UsuarioVm>(
                       false,
                       200,
                       usuarioPaginados,
                       "Sucesso ao obter a usuário"
                    );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioVm>(
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
        public async Task<IActionResult> ObterUsuarios([FromQuery] SearchUsuarioRequest searchUsuarioRequest)
        {
            try
            {
                Expression<Func<Usuario, bool>> expression = x => true;

                if (searchUsuarioRequest.UsuarioRequest is not null)
                {
                    if (searchUsuarioRequest.UsuarioRequest.UsuarioId is not null && !searchUsuarioRequest.UsuarioRequest.UsuarioId.Equals(Guid.Empty))
                    {
                        expression = AuthFilter.ConUsuario(new UsuarioVm()
                        {
                            UsuarioId = (Guid)searchUsuarioRequest.UsuarioRequest.UsuarioId,
                            NomeCompleto = searchUsuarioRequest.UsuarioRequest.NomeCompleto,
                            Telefone = searchUsuarioRequest.UsuarioRequest.Telefone,
                            CPF = searchUsuarioRequest.UsuarioRequest.CPF,
                            Email = searchUsuarioRequest.UsuarioRequest.Email,
                            Senha = searchUsuarioRequest.UsuarioRequest.Senha,
                        });
                    }
                    else
                    {
                        expression = AuthFilter.ConUsuario(new UsuarioVm()
                        {
                            NomeCompleto = searchUsuarioRequest.UsuarioRequest.NomeCompleto,
                            Telefone = searchUsuarioRequest.UsuarioRequest.Telefone,
                            CPF = searchUsuarioRequest.UsuarioRequest.CPF,
                            Email = searchUsuarioRequest.UsuarioRequest.Email,
                            Senha = searchUsuarioRequest.UsuarioRequest.Senha,
                        });
                    }
                }

                var expressionPermissaoMapping = _mapper.Map<Expression<Func<UsuarioVm, bool>>>(expression);

                var usauriosPaginados = await _usuarioService.GetUsuariosAsync(expressionPermissaoMapping);

                var resultado = new ResultDataResponse<IEnumerable<UsuarioVm>>(
                       false,
                       200,
                       usauriosPaginados,
                       "Sucesso ao obter os usuários"
                    );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<IEnumerable<UsuarioVm>>(
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
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioRequest criarUsuarioRequest)
        {
            try
            {
                var usuarioAdicionar = await _usuarioService.AddUsuarioAsync(criarUsuarioRequest);

                await _unitOfWorkService.CommitAsync();

                var resultado = new ResultDataResponse<UsuarioVm>(
                                false,
                                200,
                                usuarioAdicionar,
                                "Sucesso ao adicionar a permissao"
                            );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioVm>(
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
        public async Task<IActionResult> EditarUsuario([FromBody] EditeUsuarioRequest editeUsuarioRequest)
        {
            try
            {
                var usuarioEditar = await _usuarioService.UpdateUsuario(editeUsuarioRequest);

                await _unitOfWorkService.CommitAsync();

                var resultado = new ResultDataResponse<UsuarioVm>(
                                false,
                                200,
                                usuarioEditar,
                                "Sucesso ao editar a ususário"
                            );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioVm>(
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
        public async Task<IActionResult> ExcluirUsuario([FromBody] RemoverUsuarioRequest removerUsuarioRequest)
        {
            try
            {
                var usuarioRemover = await _usuarioService.RemoveUsuario(removerUsuarioRequest);

                await _unitOfWorkService.CommitAsync();

                var resultado = new ResultDataResponse<UsuarioVm>(
                                false,
                                200,
                                usuarioRemover,
                                "Sucesso ao excluír a ususário"
                            );

                return Json(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<UsuarioVm>(
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
