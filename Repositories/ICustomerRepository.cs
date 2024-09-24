using System.Collections.Generic;
using System.Threading.Tasks;
using uniofwork.Models; // Ensure this is the correct namespace for your models

namespace uniofwork.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer); // add new customer to customer repo
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    } 
}
