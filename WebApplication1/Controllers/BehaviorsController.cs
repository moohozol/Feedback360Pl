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
    public class BehaviorsController : Controller
    {
        private readonly FeedbacktestContext _context;

        public BehaviorsController(FeedbacktestContext context)
        {
            _context = context;
        }

        // GET: Behaviors
        public async Task<IActionResult> Index()
        {
            var feedbacktestContext = _context.Behavior.Include(b => b.Competency);
            return View(await feedbacktestContext.ToListAsync());
        }

        // GET: Behaviors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behavior = await _context.Behavior
                .Include(b => b.Competency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (behavior == null)
            {
                return NotFound();
            }

            return View(behavior);
        }

        // GET: Behaviors/Create
        public IActionResult Create()
        {
            ViewData["CompetencyId"] = new SelectList(_context.Competency, "Id", "Name");
            return View();
        }

        // POST: Behaviors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CompetencyId")] Behavior behavior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(behavior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetencyId"] = new SelectList(_context.Competency, "Id", "Name", behavior.CompetencyId);
            return View(behavior);
        }

        // GET: Behaviors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behavior = await _context.Behavior.FindAsync(id);
            if (behavior == null)
            {
                return NotFound();
            }
            ViewData["CompetencyId"] = new SelectList(_context.Competency, "Id", "Name", behavior.CompetencyId);
            return View(behavior);
        }

        // POST: Behaviors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CompetencyId")] Behavior behavior)
        {
            if (id != behavior.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(behavior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BehaviorExists(behavior.Id))
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
            ViewData["CompetencyId"] = new SelectList(_context.Competency, "Id", "Name", behavior.CompetencyId);
            return View(behavior);
        }

        // GET: Behaviors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behavior = await _context.Behavior
                .Include(b => b.Competency)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (behavior == null)
            {
                return NotFound();
            }

            return View(behavior);
        }

        // POST: Behaviors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var behavior = await _context.Behavior.FindAsync(id);
            _context.Behavior.Remove(behavior);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BehaviorExists(int id)
        {
            return _context.Behavior.Any(e => e.Id == id);
        }
    }
}
