using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using uniofwork.Data;
using uniofwork.Models;

namespace uniofwork.Repositories
{
    public class CustomerRepository : ICustomerRepository // implementing the interface 
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) // again dependency injection 
        {
            _context = context;
        }
        // interacts with _context to make actual db changes
        // can change to other dbs, without changing repo logic, thats why DI important, constructor injects applicationdbcontext via DI. No need to make a new instance. 
        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer); // add new customer to the db context customers db
             await _context.SaveChangesAsync();  // methods() 
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        // conversts customer from table customer to list
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified; // makes customer modified so that entity framework knows to keep track of it and update it in db
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
