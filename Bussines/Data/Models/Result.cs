namespace Bussines.Data.Models
{
    public class Result<T>
    {
        public string? Token { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<T> Datas { get; set; }
        public string Message { get; set; }
    }
}
