using System.Collections.Generic;
using System.Threading.Tasks;
using uniofwork.Models;

namespace uniofwork.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Orders order);
        Task<IEnumerable<Orders>> GetAllAsync();
        Task<Orders> GetByIdAsync(int id);
        Task UpdateAsync(Orders order);
        Task DeleteAsync(int id);
    }
}
