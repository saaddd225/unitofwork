using System.Threading.Tasks;
using System.Web.Mvc;
using uniofwork.Models;
using uniofwork.Repositories;

namespace uniofwork.Controllers
{
    public class CustomerController : Controller // inherits the controller mvc class for CustomerController // allows it to handle http reqs
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork) // this is called dependency injection, basically, when the class is called, it will inject IUNIT of work into unit of workl - mvc does this 
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Customers
        public async Task<ActionResult> Index() 
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View(); 
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email")] Customer customer)
        {
            if (ModelState.IsValid)  // if data
            {
                await _unitOfWork.Customers.AddAsync(customer);
                await _unitOfWork.CompleteAsync();  // Commit the transaction
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Customers.UpdateAsync(customer);
                await _unitOfWork.CompleteAsync();  // Commit the transaction
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Customers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();  // Commit the transaction
            return RedirectToAction("Index");
        }
    }
}
