namespace Bussines.Data.Models
{
    public class Pagination<T>
    {
        public int TotalItems { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public IEnumerable<T> Items { get; }

        public Pagination(int totalItems, int currentPage, int totalPages, IEnumerable<T> items)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            Items = items;
        }
    }
}
