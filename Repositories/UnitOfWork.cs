using System;
using System.Threading.Tasks;
using uniofwork.Data;


namespace uniofwork.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable // implements interfaces iunitofwork(access to diff repos and allows us to use completesync) and IDisposable( release unmamnaged resources)
    {
        private readonly ApplicationDbContext _context; // application of db class context made to use
        private ICustomerRepository _customers; 
        private IOrderRepository _orders;
        // both of these fields are instances of their repos
        public ICustomerRepository Customers
        {
            get 
            { 
                if (_customers == null)
                {
                    _customers = new CustomerRepository(_context);
                }
                return _customers; 
            }
        }
        // creates instance of customer repo is customers is null through the shared instance _context 
        // provides controlled access 
        public IOrderRepository Orders         // properties of unitofwork class
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrderRepository(_context);
                }
                return _orders;
            }
        }

        public UnitOfWork(ApplicationDbContext context, ICustomerRepository customerRepository = null, IOrderRepository orderRepository = null)
        {
            _context = context;
            _customers = customerRepository ?? new CustomerRepository(_context);
            _orders = orderRepository ?? new OrderRepository(_context);
        }
        // constructor injects appdbcontext and accepts repos, if not provided it makes its own
        public async Task<int> CompleteAsync() 
        {
            return await _context.SaveChangesAsync(); 
        }
        // returns no of rows affected so int, causes pending changes to be saved
        public void Dispose() // appdbcontext is disposed, resources get free timely when iunitofwork not needed
        {
            _context.Dispose();
        }
    }
}
