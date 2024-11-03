using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Requests.Gerenciamento.Auth;
using Bussines.Data.Requests.Searchs.Paginations;
using Bussines.Repositories;
using Bussines.Services.Interfaces;

namespace Bussines.Services
{
    public class GerenciamentoService : IGerenciamentoService
    {
        private readonly IGerenciamentoRepository _gerenciamentoRepository;

        public GerenciamentoService(IGerenciamentoRepository gerenciamentoRepository)
        {
            _gerenciamentoRepository = gerenciamentoRepository;
        }
        
        public async Task<Result<ConsumidorVm>> EntrarAsync(GerenciamentoAuthResquest gerenciamentoAuthResquest)
        {
            return await _gerenciamentoRepository.EntrarAsync(gerenciamentoAuthResquest);
        }

        public async Task<Pagination<SistemaVm>> ObterSistemaPaginado(SearchSistemaPagiantionRequest searchSistemaPagiantionRequest)
        {
            return await _gerenciamentoRepository.ObterSistemaPaginado(searchSistemaPagiantionRequest);
        }
    }
}
