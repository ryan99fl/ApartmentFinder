using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApartmentFinder.Models;

namespace ApartmentFinder.Controllers
{
    public class UtilitiesController : Controller
    {
        private readonly ApartmentFinderContext _context;

        public UtilitiesController(ApartmentFinderContext context)
        {
            _context = context;
        }

        // GET: Utilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilities.ToListAsync());
        }

        // GET: Utilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = await _context.Utilities
                .FirstOrDefaultAsync(m => m.UtilityID == id);
            if (utility == null)
            {
                return NotFound();
            }

            return View(utility);
        }

        // GET: Utilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UtilityID,UtilityType,Name,Website,EstMonRate")] Utility utility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utility);
        }

        // GET: Utilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = await _context.Utilities.FindAsync(id);
            if (utility == null)
            {
                return NotFound();
            }
            return View(utility);
        }

        // POST: Utilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UtilityID,UtilityType,Name,Website,EstMonRate")] Utility utility)
        {
            if (id != utility.UtilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilityExists(utility.UtilityID))
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
            return View(utility);
        }

        // GET: Utilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = await _context.Utilities
                .FirstOrDefaultAsync(m => m.UtilityID == id);
            if (utility == null)
            {
                return NotFound();
            }

            return View(utility);
        }

        // POST: Utilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utility = await _context.Utilities.FindAsync(id);
            if (utility != null)
            {
                _context.Utilities.Remove(utility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilityExists(int id)
        {
            return _context.Utilities.Any(e => e.UtilityID == id);
        }
    }
}
