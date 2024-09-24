using System.Threading.Tasks;

namespace uniofwork.Repositories
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        Task<int> CompleteAsync(); // Ensure this method is async
    }
}
