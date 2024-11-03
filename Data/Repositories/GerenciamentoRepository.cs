using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Requests.Gerenciamento.Auth;
using Bussines.Data.Requests.Searchs.Paginations;
using Data.Apis;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class GerenciamentoRepository : IGerenciamentoRepository
    {
        private readonly IGerenciamentoAuthApi _gerenciamentoAuthApi;
        private readonly IGerenciamentoSistemasApi _gerenciamentoSistemasApi;

        public GerenciamentoRepository(
            IGerenciamentoAuthApi gerenciamentoAuthApi,
            IGerenciamentoSistemasApi gerenciamentoSistemasApi
            )
        {
            _gerenciamentoAuthApi = gerenciamentoAuthApi;
            _gerenciamentoSistemasApi = gerenciamentoSistemasApi;
        }

        public async Task<Result<ConsumidorVm>> EntrarAsync(GerenciamentoAuthResquest gerenciamentoAuthResquest)
        {
            return await _gerenciamentoAuthApi.EntrarAsync(gerenciamentoAuthResquest);
        }

        public async Task<Pagination<SistemaVm>> ObterSistemaPaginado(SearchSistemaPagiantionRequest searchSistemaPagiantionRequest)
        {
            return await _gerenciamentoSistemasApi.ObterSistemaPaginado(searchSistemaPagiantionRequest);
        }
    }
}
