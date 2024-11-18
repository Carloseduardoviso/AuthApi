using AutoMapper;
using Bussines.Data.Entityes;
using Bussines.Data.Models;
using Bussines.Data.Requests.UsuarioSistema;
using Bussines.Repositories;
using Bussines.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace Bussines.Services
{
    public class UsuarioSistemaService : IUsuarioSistemaService
    {
        private readonly IUsuarioSistemaRepository _usuarioSistemaRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioSistemaService(
            IUsuarioSistemaRepository usuarioSistemaRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _usuarioSistemaRepository = usuarioSistemaRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UsuarioSistemaVm> AddUsuarioAsync(CriarUsuarioSistemaRequest criarUsuarioSistemaRequest)
        {

            var usuarioSistema = new UsuarioSistemaVm()
            {
              UsuarioId = criarUsuarioSistemaRequest.UsuarioId,
              SistemaId = criarUsuarioSistemaRequest.SistemaId
            };

            var usuarioSistemaAdicionado = await _usuarioSistemaRepository.AddAsync(_mapper.Map<UsuarioSistema>(usuarioSistema));

            return _mapper.Map<UsuarioSistemaVm>(usuarioSistemaAdicionado);
        }

        public IEnumerable<UsuarioSistemaVm> AddUsuariosRange(IEnumerable<UsuarioSistemaVm> usuarios)
        {
            var usuarioAdicionadoRange = _usuarioSistemaRepository.AddRange(_mapper.Map<IEnumerable<UsuarioSistema>>(usuarios));
            return _mapper.Map<IEnumerable<UsuarioSistemaVm>>(usuarioAdicionadoRange);
        }

        public async Task<UsuarioSistemaVm> UpdateUsuario(EditeUsuarioSistemaRequest editeUsuarioSistemaRequest)
        {
            var usuarioSistemaExiste = await _usuarioSistemaRepository.GetEntityObjectAsync(x => x.UsuarioId.Equals(editeUsuarioSistemaRequest.UsuarioId) && x.SistemaId.Equals(editeUsuarioSistemaRequest.SistemaId), true);

            if (usuarioSistemaExiste is null)
            {
                throw new Exception("Usuário associado ao Sistema não encontrado para ser remover");
            }

            var usuarioSistema = _mapper.Map<UsuarioSistemaVm>(editeUsuarioSistemaRequest);

            usuarioSistema.UsuarioId = editeUsuarioSistemaRequest.UsuarioId;
            usuarioSistema.SistemaId = editeUsuarioSistemaRequest.SistemaId;

            var usuarioSistemaAtualizado = _usuarioSistemaRepository.Update(_mapper.Map<UsuarioSistema>(usuarioSistema));

            return _mapper.Map<UsuarioSistemaVm>(usuarioSistemaAtualizado);
        }

        public async Task<UsuarioSistemaVm> RemoveUsuario(RemoverUsuarioSistemaRequest removerUsuarioSistemaRequest)
        {
            var usuarioSistemaExiste = await _usuarioSistemaRepository.GetEntityObjectAsync(x => x.UsuarioId.Equals(removerUsuarioSistemaRequest.UsuarioId) && x.SistemaId.Equals(removerUsuarioSistemaRequest.SistemaId), true);

            if (usuarioSistemaExiste is null)
            {
                throw new Exception("Usuário associado ao Sistema não encontrado para ser remover");
            }

            var usuarioSistemaAtualizado = await _usuarioSistemaRepository.Remove(usuarioSistemaExiste);

            return _mapper.Map<UsuarioSistemaVm>(usuarioSistemaAtualizado);
        }

        public async Task<Pagination<UsuarioSistemaVm>> GetAllUsuarioPaginationAsync(Expression<Func<UsuarioSistemaVm, bool>>? expression = null, int pageNumber = 1, int pageSize = 10, bool asNoTracking = true, params Expression<Func<UsuarioSistemaVm, object>>[]? includes)
        {
            var expressionMaping = _mapper.Map<Expression<Func<UsuarioSistema, bool>>?>(expression);
            var includeMaping = _mapper.Map<Expression<Func<UsuarioSistema, object>>[]?>(includes);

            var resultado = _mapper.Map<Pagination<UsuarioSistemaVm>>(await _usuarioSistemaRepository.GetAllPaginationAsync(expressionMaping, pageNumber, pageSize, asNoTracking, includeMaping));

            return resultado;
        }

        public async Task<UsuarioSistemaVm?> GetUsuarioAsync(Expression<Func<UsuarioSistemaVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioSistemaVm, object>>[]? includes)
        {
            var expressionMaping = _mapper.Map<Expression<Func<UsuarioSistema, bool>>?>(expression);
            var includeMaping = _mapper.Map<Expression<Func<UsuarioSistema, object>>[]?>(includes);

            var resultado = _mapper.Map<UsuarioSistemaVm>(await _usuarioSistemaRepository.GetEntityObjectAsync(expressionMaping, asNoTracking, includeMaping));

            return resultado;
        }

        public async Task<IEnumerable<UsuarioSistemaVm>> GetUsuariosAsync(Expression<Func<UsuarioSistemaVm, bool>>? expression = null, bool asNoTracking = false, params Expression<Func<UsuarioSistemaVm, object>>[]? includes)
        {
            var expressionMaping = _mapper.Map<Expression<Func<UsuarioSistema, bool>>?>(expression);
            var includeMaping = _mapper.Map<Expression<Func<UsuarioSistema, object>>[]?>(includes);

            var resultado = _mapper.Map<IEnumerable<UsuarioSistemaVm>>(await _usuarioSistemaRepository.GetEntityObjectsAsync(expressionMaping, asNoTracking, includeMaping));

            return resultado;
        }
    }
}
