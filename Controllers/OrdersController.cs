using System.Threading.Tasks;
using System.Web.Mvc;
using uniofwork.Models;
using uniofwork.Repositories;

namespace uniofwork.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CustomerId,Product")] Orders order)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.CompleteAsync();  // Commit the transaction
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CustomerId,Product")] Orders order)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.CompleteAsync();  // Commit the transaction
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Orders.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();  // Commit the transaction
            return RedirectToAction("Index");
        }
    }
}
