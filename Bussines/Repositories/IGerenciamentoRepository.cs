using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Models;
using Bussines.Data.Requests.Gerenciamento.Auth;
using Bussines.Data.Requests.Searchs.Paginations;

namespace Bussines.Repositories
{
    public interface IGerenciamentoRepository
    {
        #region Auth

        Task<Result<ConsumidorVm>> EntrarAsync(GerenciamentoAuthResquest gerenciamentoAuthResquest);

        #endregion Auth

        #region Sistema

        Task<Pagination<SistemaVm>> ObterSistemaPaginado(SearchSistemaPagiantionRequest searchSistemaPagiantionRequest);

        #endregion Sistema

    }
}
