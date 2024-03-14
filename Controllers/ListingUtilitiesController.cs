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
    public class ListingUtilitiesController : Controller
    {
        private readonly ApartmentFinderContext _context;

        public ListingUtilitiesController(ApartmentFinderContext context)
        {
            _context = context;
        }

        // GET: ListingUtilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListingUtilities.ToListAsync());
        }

        // GET: ListingUtilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listingUtility = await _context.ListingUtilities
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (listingUtility == null)
            {
                return NotFound();
            }

            return View(listingUtility);
        }

        // GET: ListingUtilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListingUtilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceID,UtilityID,ListingID,UtilitiesEstimate")] ListingUtility listingUtility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listingUtility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listingUtility);
        }

        // GET: ListingUtilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listingUtility = await _context.ListingUtilities.FindAsync(id);
            if (listingUtility == null)
            {
                return NotFound();
            }
            return View(listingUtility);
        }

        // POST: ListingUtilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceID,UtilityID,ListingID,UtilitiesEstimate")] ListingUtility listingUtility)
        {
            if (id != listingUtility.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listingUtility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingUtilityExists(listingUtility.ServiceID))
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
            return View(listingUtility);
        }

        // GET: ListingUtilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listingUtility = await _context.ListingUtilities
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (listingUtility == null)
            {
                return NotFound();
            }

            return View(listingUtility);
        }

        // POST: ListingUtilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listingUtility = await _context.ListingUtilities.FindAsync(id);
            if (listingUtility != null)
            {
                _context.ListingUtilities.Remove(listingUtility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListingUtilityExists(int id)
        {
            return _context.ListingUtilities.Any(e => e.ServiceID == id);
        }
    }
}
