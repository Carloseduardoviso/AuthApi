namespace Bussines.Data.Responses
{
    public record ResultDataResponse<TModel>(bool IsSuccess = false, int StatusCode = 500, TModel? Data = default, string? ErrorMessage = null);
}
