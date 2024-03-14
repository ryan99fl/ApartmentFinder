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
    public class ZipcodesController : Controller
    {
        private readonly ApartmentFinderContext _context;

        public ZipcodesController(ApartmentFinderContext context)
        {
            _context = context;
        }

        // GET: Zipcodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZipCodes.ToListAsync());
        }

        // GET: Zipcodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zipcode = await _context.ZipCodes
                .FirstOrDefaultAsync(m => m.ZipCode == id);
            if (zipcode == null)
            {
                return NotFound();
            }

            return View(zipcode);
        }

        // GET: Zipcodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zipcodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZipCode,City,State")] Zipcode zipcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zipcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zipcode);
        }

        // GET: Zipcodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zipcode = await _context.ZipCodes.FindAsync(id);
            if (zipcode == null)
            {
                return NotFound();
            }
            return View(zipcode);
        }

        // POST: Zipcodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ZipCode,City,State")] Zipcode zipcode)
        {
            if (id != zipcode.ZipCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zipcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZipcodeExists(zipcode.ZipCode))
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
            return View(zipcode);
        }

        // GET: Zipcodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zipcode = await _context.ZipCodes
                .FirstOrDefaultAsync(m => m.ZipCode == id);
            if (zipcode == null)
            {
                return NotFound();
            }

            return View(zipcode);
        }

        // POST: Zipcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zipcode = await _context.ZipCodes.FindAsync(id);
            if (zipcode != null)
            {
                _context.ZipCodes.Remove(zipcode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZipcodeExists(string id)
        {
            return _context.ZipCodes.Any(e => e.ZipCode == id);
        }
    }
}
