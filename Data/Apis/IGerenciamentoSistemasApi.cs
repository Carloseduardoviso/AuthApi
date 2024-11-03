using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Requests.Searchs.Paginations;
using Refit;

namespace Data.Apis
{
    public interface IGerenciamentoSistemasApi
    {
        [Get("/v1/api/Gerenciamento/ObterSistemaPaginado")]
        Task<Pagination<SistemaVm>> ObterSistemaPaginado(SearchSistemaPagiantionRequest searchSistemaPagiantionRequest);
    }
}
