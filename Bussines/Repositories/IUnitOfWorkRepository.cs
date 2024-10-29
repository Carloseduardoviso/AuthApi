namespace Bussines.Repositories
{
    public interface IUnitOfWorkRepository
    {
        Task CommitAsync();
        Task Roolback();
    }
}
