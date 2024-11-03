using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Requests.Gerenciamento.Auth;
using Bussines.Data.Requests.Searchs.Paginations;

namespace Bussines.Services.Interfaces
{
    public interface IGerenciamentoService
    {
        Task<Result<ConsumidorVm>> EntrarAsync(GerenciamentoAuthResquest gerenciamentoAuthResquest);
        Task<Pagination<SistemaVm>> ObterSistemaPaginado(SearchSistemaPagiantionRequest searchSistemaPagiantionRequest);
    }
}
