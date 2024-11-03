using Bussines.Data.Requests.Gerenciamento.Sistema;

namespace Bussines.Data.Requests.Searchs.Paginations
{
    public record SearchSistemaPagiantionRequest(SistemaRequest? SistemaRequest = null, int PageNumber = 1, int PageSize = 10, List<string>? Includes = null);
}
