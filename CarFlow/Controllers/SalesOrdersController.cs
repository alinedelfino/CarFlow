using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarFlow.Models;

namespace CarFlow.Controllers
{
    public class SalesOrdersController : Controller
    {
        private readonly CarFlowContext _context;

        public SalesOrdersController(CarFlowContext context)
        {
            _context = context;    
        }

        // GET: SalesOrders
        public async Task<IActionResult> Index()
        {
            var carFlowContext = _context.SalesOrder.Include(s => s.Customer).Include(s => s.SalesAdvisor);
            return View(await carFlowContext.ToListAsync());
        }

        // GET: SalesOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrder
                .Include(s => s.Customer)
                .Include(s => s.SalesAdvisor)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // GET: SalesOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "ID", "ID");
            ViewData["SalesAdvisorId"] = new SelectList(_context.SalesAdvisor, "ID", "ID");
            return View();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductName,SalePrice,SaleDate,SalesAdvisorId,CustomerId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "ID", "ID", salesOrder.CustomerId);
            ViewData["SalesAdvisorId"] = new SelectList(_context.SalesAdvisor, "ID", "ID", salesOrder.SalesAdvisorId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrder.SingleOrDefaultAsync(m => m.ID == id);
            if (salesOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "ID", "ID", salesOrder.CustomerId);
            ViewData["SalesAdvisorId"] = new SelectList(_context.SalesAdvisor, "ID", "ID", salesOrder.SalesAdvisorId);
            return View(salesOrder);
        }

        // POST: SalesOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductName,SalePrice,SaleDate,SalesAdvisorId,CustomerId")] SalesOrder salesOrder)
        {
            if (id != salesOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderExists(salesOrder.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "ID", "ID", salesOrder.CustomerId);
            ViewData["SalesAdvisorId"] = new SelectList(_context.SalesAdvisor, "ID", "ID", salesOrder.SalesAdvisorId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrder
                .Include(s => s.Customer)
                .Include(s => s.SalesAdvisor)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // POST: SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrder = await _context.SalesOrder.SingleOrDefaultAsync(m => m.ID == id);
            _context.SalesOrder.Remove(salesOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SalesOrderExists(int id)
        {
            return _context.SalesOrder.Any(e => e.ID == id);
        }
    }
}
