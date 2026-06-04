using BookingSystem.DB;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BlobService _blobService;

        public EventsController(ApplicationDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        // Helper to populate Category Dropdown
        private void PopulateCategories(object selectedCategory = null)
        {
            ViewBag.EventTypeID = new SelectList(_context.EventTypes, "EventTypeID", "Name", selectedCategory);
        }

        // GET: Events
        public async Task<IActionResult> Index() => View(await _context.Events.Include(e => e.EventType).ToListAsync());

        // GET: Events/Create
        public IActionResult Create()
        {
            PopulateCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event @event, IFormFile? ImageUpload)
        {
            ModelState.Remove("ImageUpload");
            ModelState.Remove("ImageUrl");

            if (!ModelState.IsValid)
            {
                PopulateCategories(@event.EventTypeID);
                return View(@event);
            }


            if (ImageUpload != null)
            {
                try
                {
                    @event.ImageUrl = await _blobService.UploadFileAsync(ImageUpload, "event-images");
                }
                catch (Exception fileEx)
                {
                    ModelState.AddModelError("", $"File error: {fileEx.Message}");
                    PopulateCategories(@event.EventTypeID);
                    return View(@event);
                }
            }

            try
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Database error occurred while saving the event.");
                PopulateCategories(@event.EventTypeID);
                return View(@event);
            }
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var @event = await _context.Events.FindAsync(id);
            if (@event == null) return NotFound();

            PopulateCategories(@event.EventTypeID);
            return View(@event);
        }


        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event @event, IFormFile? ImageUpload)
        {
            if (id != @event.EventID) return NotFound();

            ModelState.Remove("ImageUpload");
            ModelState.Remove("ImageUrl");

            if (!ModelState.IsValid)
            {
                PopulateCategories(@event.EventTypeID);
                return View(@event);
            }

            try
            {
                if (ImageUpload != null)
                {
                    @event.ImageUrl = await _blobService.UploadFileAsync(ImageUpload, "event-images");
                }
                else
                {
                    var existingEvent = await _context.Events.AsNoTracking().FirstOrDefaultAsync(e => e.EventID == id);
                    if (existingEvent != null) @event.ImageUrl = existingEvent.ImageUrl;
                }

                _context.Update(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Database error occurred during update.");
                PopulateCategories(@event.EventTypeID);
                return View(@event);
            }
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            // Use Include to load the related EventType object for display
            var @event = await _context.Events.Include(e => e.EventType).FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null) return NotFound();
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int id) => View(await _context.Events.Include(e => e.EventType).FirstOrDefaultAsync(e => e.EventID == id));

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null) return NotFound();

            if (await _context.Bookings.AnyAsync(b => b.EventID == id))
            {
                TempData["Error"] = "Cannot delete: This event has active bookings.";
                return RedirectToAction(nameof(Index));
            }

            if (!string.IsNullOrEmpty(@event.ImageUrl))
            {
                await _blobService.DeleteBlobAsync(@event.ImageUrl, "event-images");
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Gemini, 2026