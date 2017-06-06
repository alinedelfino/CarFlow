using CarFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarFlow.Controllers
{
    public class SalesAdvisorsController : Controller
    {
        private readonly CarFlowContext _context;

        public SalesAdvisorsController(CarFlowContext context)
        {
            _context = context;    
        }

        // GET: SalesAdvisors
        public async Task<IActionResult> Index(string name)
        {
            // Use LINQ to get list of rates.            
            var salesAdvisor = from m in _context.SalesAdvisor
                         select m;

            var salesOrder = from m in _context.SalesOrder
                               select m;

            // Get the ID of the sales Advisor
            var ratingAverage = 0.0;
            var numSales = 0;
            if (!String.IsNullOrEmpty(name))
            {
                salesAdvisor = salesAdvisor.Where(x => x.Name.Contains(name));

                // Now get all the sales orders from this particular saleAdvisor
                //var salesAdvisorID = salesAdvisor.ElementAt(0).ID;
                var salesAdvisorID = salesAdvisor.First().ID;
                salesOrder = salesOrder.Where(x => x.SalesAdvisorId == salesAdvisorID);

                // Get number of sales
                numSales = salesOrder.Count();

                // If there was any sail get the average rating
                if (salesOrder.Any()) {              
                    var sales = salesOrder.ToList();

                    // Probably not the best LINQ way...              
                    foreach (var element in sales)
                    {
                        var survey = from m in _context.Survey
                                     select m;
                        survey = survey.Where(x => x.SalesOrderId == element.ID);
                        ratingAverage += survey.First().Rate;
                    }
                    ratingAverage /= sales.Count();                                        
                }                

            }

            // Populate model
            var salesAdvisorInfo = new SalesAdvisorRateInfo();
            salesAdvisorInfo.avgRating = ratingAverage;
            salesAdvisorInfo.numSales = numSales;
            salesAdvisorInfo.salesAdvisor = await _context.SalesAdvisor.ToListAsync();

            return View(salesAdvisorInfo);
        }

        // GET: SalesAdvisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesAdvisor = await _context.SalesAdvisor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salesAdvisor == null)
            {
                return NotFound();
            }

            return View(salesAdvisor);
        }

        // GET: SalesAdvisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesAdvisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Telephone,BirthDay,Sallary")] SalesAdvisor salesAdvisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesAdvisor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(salesAdvisor);
        }

        // GET: SalesAdvisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesAdvisor = await _context.SalesAdvisor.SingleOrDefaultAsync(m => m.ID == id);
            if (salesAdvisor == null)
            {
                return NotFound();
            }
            return View(salesAdvisor);
        }

        // POST: SalesAdvisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Telephone,BirthDay,Sallary")] SalesAdvisor salesAdvisor)
        {
            if (id != salesAdvisor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesAdvisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesAdvisorExists(salesAdvisor.ID))
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
            return View(salesAdvisor);
        }

        // GET: SalesAdvisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesAdvisor = await _context.SalesAdvisor
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salesAdvisor == null)
            {
                return NotFound();
            }

            return View(salesAdvisor);
        }

        // POST: SalesAdvisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesAdvisor = await _context.SalesAdvisor.SingleOrDefaultAsync(m => m.ID == id);
            _context.SalesAdvisor.Remove(salesAdvisor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SalesAdvisorExists(int id)
        {
            return _context.SalesAdvisor.Any(e => e.ID == id);
        }
    }
}
