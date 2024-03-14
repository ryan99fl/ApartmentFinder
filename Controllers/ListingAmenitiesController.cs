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
    public class ListingAmenitiesController : Controller
    {
        private readonly ApartmentFinderContext _context;

        public ListingAmenitiesController(ApartmentFinderContext context)
        {
            _context = context;
        }

        // GET: ListingAmenities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListingAmenities.ToListAsync());
        }

        // GET: ListingAmenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listingAmenity = await _context.ListingAmenities
                .FirstOrDefaultAsync(m => m.ListingID == id);
            if (listingAmenity == null)
            {
                return NotFound();
            }

            return View(listingAmenity);
        }

        // GET: ListingAmenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListingAmenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListingID,AmenityID,Notes")] ListingAmenity listingAmenity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listingAmenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listingAmenity);
        }

        // GET: ListingAmenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listingAmenity = await _context.ListingAmenities.FindAsync(id);
            if (listingAmenity == null)
            {
                return NotFound();
            }
            return View(listingAmenity);
        }

        // POST: ListingAmenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListingID,AmenityID,Notes")] ListingAmenity listingAmenity)
        {
            if (id != listingAmenity.ListingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listingAmenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingAmenityExists(listingAmenity.ListingID))
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
            return View(listingAmenity);
        }

        // GET: ListingAmenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listingAmenity = await _context.ListingAmenities
                .FirstOrDefaultAsync(m => m.ListingID == id);
            if (listingAmenity == null)
            {
                return NotFound();
            }

            return View(listingAmenity);
        }

        // POST: ListingAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listingAmenity = await _context.ListingAmenities.FindAsync(id);
            if (listingAmenity != null)
            {
                _context.ListingAmenities.Remove(listingAmenity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListingAmenityExists(int id)
        {
            return _context.ListingAmenities.Any(e => e.ListingID == id);
        }
    }
}
