using Bussines.Data.Models;
using Bussines.Data.Models.Gerenciamento;
using Bussines.Data.Requests.Gerenciamento.Auth;
using Refit;

namespace Data.Apis
{
    public interface IGerenciamentoAuthApi
    {
        [Post("/v1/api/Gerenciamento/EntrarAsync")]
        Task<Result<ConsumidorVm>> EntrarAsync(GerenciamentoAuthResquest gerenciamentoAuthResquest);
    }
}
