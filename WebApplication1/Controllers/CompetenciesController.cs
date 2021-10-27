using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompetenciesController : Controller
    {
        private readonly FeedbacktestContext _context;

        public CompetenciesController(FeedbacktestContext context)
        {
            _context = context;
        }

        // GET: Competencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competency.ToListAsync());
        }

        // GET: Competencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competency = await _context.Competency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competency == null)
            {
                return NotFound();
            }

            return View(competency);
        }

        // GET: Competencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Keywords")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competency);
        }

        // GET: Competencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competency = await _context.Competency.FindAsync(id);
            if (competency == null)
            {
                return NotFound();
            }
            return View(competency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Keywords")] Competency competency)
        {
            if (id != competency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetencyExists(competency.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(competency);
        }

        // GET: Competencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competency = await _context.Competency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competency == null)
            {
                return NotFound();
            }

            return View(competency);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competency = await _context.Competency.FindAsync(id);
            _context.Competency.Remove(competency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetencyExists(int id)
        {
            return _context.Competency.Any(e => e.Id == id);
        }
    }
}
