using AutoMapper;
using Businnes.Helpers.Custons;
using Bussines.Data.Entityes;
using Bussines.Data.Models;
using Bussines.Data.Requests.Usuario;
using Bussines.Data.Responses;
using Bussines.Data.Responses.Usuario;
using Bussines.Repositories;
using Bussines.Services.Interfaces;
using Custom_Identity.Helpers.Custons;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace Bussines.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usaurioRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioService(
            IUsuarioRepository usaurioRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _usaurioRepository = usaurioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        #region Auth

        public async Task<AuthResponse> GetAuthAsync(Expression<Func<UsuarioVm, bool>>? expression = null, bool asNoTracking = false)
        {
            var expressionMaping = _mapper.Map<Expression<Func<Usuario, bool>>?>(expression);

            var usuarioExiste = _mapper.Map<UsuarioVm>(await _usaurioRepository.GetEntityObjectAsync(expressionMaping, asNoTracking));

            UsuarioResponse usaurioResponse = null;

            if (usuarioExiste is null)
            {
                throw new Exception("Usuário não encontrado para ser authenticado");
            }


            var token = TokenService.GenerateToken(usuarioExiste, _configuration);

            usaurioResponse = new UsuarioResponse(
                usuarioExiste.UsuarioId,
                usuarioExiste.NomeCompleto,
                usuarioExiste.Telefone,
                usuarioExiste.CPF,
                usuarioExiste.Email,
                usuarioExiste.Senha,
                usuarioExiste.TipoPermissao
                );

            return new AuthResponse(token, usaurioResponse);
        }

        #endregion Auth

        #region Usuario
        public async Task<UsuarioVm> AddUsuarioAsync(CriarUsuarioRequest criarUsuarioRequest)
        {

            var usuario = new UsuarioVm()
            {
                NomeCompleto = criarUsuarioRequest.NomeCompleto,
                Telefone = criarUsuarioRequest.Telefone,
                CPF = criarUsuarioRequest.CPF,
                Email = criarUsuarioRequest.Email,
                Senha = criarUsuarioRequest.Senha,
                TipoPermissao = criarUsuarioRequest.TipoPermissao
            };

            usuario.Senha = CriptografiaPassword.Execute(usuario.Senha);

            var usuarioAdicionado = await _usaurioRepository.AddAsync(_mapper.Map<Usuario>(usuario));

            return _mapper.Map<UsuarioVm>(usuarioAdicionado);
        }

        public IEnumerable<UsuarioVm> AddUsuariosRange(IEnumerable<UsuarioVm> usuarios)
        {
            var usuarioAdicionadoRange = _usaurioRepository.AddRange(_mapper.Map<IEnumerable<Usuario>>(usuarios));
            return _mapper.Map<IEnumerable<UsuarioVm>>(usuarioAdicionadoRange);
        }

        public async Task<UsuarioVm> UpdateUsuario(EditeUsuarioRequest editeUsuarioRequest)
        {
            var usuarioExiste = await _usaurioRepository.GetEntityObjectAsync(x => x.UsuarioId.Equals(editeUsuarioRequest.UsuarioId), true);

            if (usuarioExiste is null)
            {
                throw new Exception("Usuário não encontrado para ser atualizado");
            }

            var usuario = _mapper.Map<UsuarioVm>(usuarioExiste);

            usuario.NomeCompleto = editeUsuarioRequest.NomeCompleto;
            usuario.Telefone = editeUsuarioRequest.Telefone;
            usuario.CPF = editeUsuarioRequest.CPF;
            usuario.Email = editeUsuarioRequest.Email;
            usuario.Senha = editeUsuarioRequest.Senha;
            usuario.TipoPermissao = usuario.TipoPermissao;

            var consumidorAtualizado = _usaurioRepository.Update(_mapper.Map<Usuario>(usuario));

            return _mapper.Map<UsuarioVm>(consumidorAtualizado);
        }

        public async Task<UsuarioVm> RemoveUsuario(RemoverUsuarioRequest removerUsuarioRequest)
        {
            var usuarioExiste = await _usaurioRepository.GetEntityObjectAsync(x => x.UsuarioId.Equals(removerUsuarioRequest.UsuarioId), true);

            if (usuarioExiste is null)
            {
                throw new Exception("Usuário não encontrado para ser remover");
            }

            var usuarioAtualizado = await _usaurioRepository.Remove(usuarioExiste);

            return _mapper.Map<UsuarioVm>(usuarioAtualizado);
        }

        public async Task<Pagination<UsuarioVm>> GetAllUsuarioPaginationAsync(Expression<Func<UsuarioVm, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<UsuarioVm, object>>[]? includes)
        {
            var expressionMaping = _mapper.Map<Expression<Func<Usuario, bool>>?>(expression);
            var includeMaping = _mapper.Map<Expression<Func<Usuario, object>>[]?>(includes);

            var resultado = _mapper.Map<Pagination<UsuarioVm>>(await _usaurioRepository.GetAllPaginationAsync(expressionMaping, pageNumber, pageSize, asNoTracking, includeMaping));

            return resultado;
        }

        public async Task<UsuarioVm?> GetUsuarioAsync(Expression<Func<UsuarioVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioVm, object>>[]? includes)
        {
            var expressionMaping = _mapper.Map<Expression<Func<Usuario, bool>>?>(expression);
            var includeMaping = _mapper.Map<Expression<Func<Usuario, object>>[]?>(includes);

            var resultado = _mapper.Map<UsuarioVm>(await _usaurioRepository.GetEntityObjectAsync(expressionMaping, asNoTracking, includeMaping));

            return resultado;
        }

        public async Task<IEnumerable<UsuarioVm>> GetUsuariosAsync(Expression<Func<UsuarioVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioVm, object>>[]? includes)
        {
            var expressionMaping = _mapper.Map<Expression<Func<Usuario, bool>>?>(expression);
            var includeMaping = _mapper.Map<Expression<Func<Usuario, object>>[]?>(includes);

            var resultado = _mapper.Map<IEnumerable<UsuarioVm>>(await _usaurioRepository.GetEntityObjectsAsync(expressionMaping, asNoTracking, includeMaping));

            return resultado;
        }

        #endregion Usuario
    }
}
