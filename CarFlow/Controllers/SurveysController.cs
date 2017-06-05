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
    public class SurveysController : Controller
    {
        private readonly CarFlowContext _context;

        public SurveysController(CarFlowContext context)
        {
            _context = context;    
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var carFlowContext = _context.Survey.Include(s => s.SalesOrder);
            return View(await carFlowContext.ToListAsync());
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .Include(s => s.SalesOrder)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrder, "ID", "ID");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rate,Easy,Friendly,EnoughInfo,Recomend,Suggestion,SalesOrderId")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrder, "ID", "ID", survey.SalesOrderId);
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey.SingleOrDefaultAsync(m => m.ID == id);
            if (survey == null)
            {
                return NotFound();
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrder, "ID", "ID", survey.SalesOrderId);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Rate,Easy,Friendly,EnoughInfo,Recomend,Suggestion,SalesOrderId")] Survey survey)
        {
            if (id != survey.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.ID))
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
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrder, "ID", "ID", survey.SalesOrderId);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .Include(s => s.SalesOrder)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survey = await _context.Survey.SingleOrDefaultAsync(m => m.ID == id);
            _context.Survey.Remove(survey);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SurveyExists(int id)
        {
            return _context.Survey.Any(e => e.ID == id);
        }
    }
}
