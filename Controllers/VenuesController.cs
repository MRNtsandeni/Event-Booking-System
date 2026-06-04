using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingSystem.DB;
using BookingSystem.Models;
using BookingSystem.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BookingSystem.Controllers
{
    public class VenuesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BlobService _blobService;

        public VenuesController(ApplicationDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        // GET: Venues
        public async Task<IActionResult> Index() => View(await _context.Venues.ToListAsync());

        // GET: Venues/Create
        public IActionResult Create() => View();

        // POST: Venues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Venue venue, IFormFile? VenueImage)
        {
            ModelState.Remove("VenueImage");
            ModelState.Remove("ImageUrl");

            if (VenueImage != null)
            {
                try
                {
                    venue.ImageUrl = await _blobService.UploadFileAsync(VenueImage, "venue-images");
                }
                catch (Exception fileEx)
                {
                    return Content($"FILE SYSTEM ERROR: Could not save the uploaded venue image file. Details: {fileEx.Message}");
                }
            }
            else
            {
                venue.ImageUrl = "";
            }

            try
            {
                _context.Add(venue); // 'venue' object now includes Capacity from the form
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception dbEx)
            {
                var errorMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : dbEx.Message;
                return Content($"DATABASE ERROR: The file saved successfully, but the database connection rejected the record entry. Details: {errorMessage}");
            }
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        // POST: Venues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Venue venue, IFormFile? VenueImage)
        {
            if (id != venue.VenueID) return NotFound();

            ModelState.Remove("VenueImage");
            ModelState.Remove("ImageUrl");

            try
            {
                if (VenueImage != null)
                {
                    venue.ImageUrl = await _blobService.UploadFileAsync(VenueImage, "venue-images");
                }
                else
                {
                    var existingVenue = await _context.Venues.AsNoTracking().FirstOrDefaultAsync(v => v.VenueID == id);
                    if (existingVenue != null)
                    {
                        venue.ImageUrl = existingVenue.ImageUrl;
                    }
                }

                _context.Update(venue); // 'venue' object now includes the updated Capacity
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception dbEx)
            {
                var errorMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : dbEx.Message;
                return Content($"EDIT DATABASE ERROR: {errorMessage}");
            }
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var venue = await _context.Venues.FirstOrDefaultAsync(m => m.VenueID == id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int id) => View(await _context.Venues.FindAsync(id));

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return NotFound();

            bool isUsed = await _context.Bookings.AnyAsync(b => b.VenueID == id);
            if (isUsed)
            {
                TempData["Error"] = "Cannot delete: This venue has active bookings.";
                return RedirectToAction(nameof(Index));
            }

            if (!string.IsNullOrEmpty(venue.ImageUrl))
            {
                await _blobService.DeleteBlobAsync(venue.ImageUrl, "venue-images");
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Gemini, 2026