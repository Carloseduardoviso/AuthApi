namespace Bussines.Data.Responses
{
    public record ResultDatasResponse<TModel>(bool IsSuccess = false, int StatusCode = 500, IEnumerable<TModel>? Data = default, string? ErrorMessage = null);
}
