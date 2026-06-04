using BookingSystem.DB;
using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BookingSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int? eventTypeId, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.BookingSummaries.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(b => b.EventName.Contains(searchString) || b.BookingID.ToString() == searchString);

            if (startDate.HasValue)
                query = query.Where(b => b.StartDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(b => b.StartDate <= endDate.Value);

            if (eventTypeId.HasValue)
                query = query.Where(b => b.EventTypeID == eventTypeId.Value);

            ViewBag.EventTypeID = new SelectList(await _context.EventTypes.ToListAsync(), "EventTypeID", "Name", eventTypeId);

            return View(await query.ToListAsync());
        }

        public IActionResult Create()
        {
            var viewModel = new BookingViewModel
            {
                Venues = GetVenuesList(),
                Events = GetEventsList(),
                EventTypes = GetEventTypesList(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(2)
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool isConflict = _context.Bookings.Any(b =>
                    b.VenueID == viewModel.SelectedVenueID &&
                    viewModel.StartDate < b.EndDate &&
                    b.StartDate < viewModel.EndDate);

                if (isConflict)
                {
                    ModelState.AddModelError("", "This venue is already booked for the selected time.");
                }
                else
                {
                    var booking = new Booking
                    {
                        VenueID = viewModel.SelectedVenueID,
                        EventID = viewModel.SelectedEventID,
                        EventTypeID = viewModel.SelectedEventTypeID,
                        StartDate = viewModel.StartDate,
                        EndDate = viewModel.EndDate,
                        BookingStatus = "Confirmed"
                    };

                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            viewModel.Venues = GetVenuesList();
            viewModel.Events = GetEventsList();
            viewModel.EventTypes = GetEventTypesList();
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            var viewModel = new BookingViewModel
            {
                BookingID = booking.BookingID,
                SelectedVenueID = booking.VenueID,
                SelectedEventID = booking.EventID,
                SelectedEventTypeID = booking.EventTypeID,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Venues = GetVenuesList(),
                Events = GetEventsList(),
                EventTypes = GetEventTypesList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingViewModel viewModel)
        {
            if (id != viewModel.BookingID) return NotFound();

            if (ModelState.IsValid)
            {
                bool isConflict = _context.Bookings.Any(b =>
                    b.VenueID == viewModel.SelectedVenueID &&
                    b.BookingID != id &&
                    viewModel.StartDate < b.EndDate &&
                    b.StartDate < viewModel.EndDate);

                if (isConflict)
                {
                    ModelState.AddModelError("", "This venue is already booked for the selected time.");
                }
                else
                {
                    try
                    {
                        var booking = await _context.Bookings.FindAsync(id);
                        if (booking == null) return NotFound();

                        booking.VenueID = viewModel.SelectedVenueID;
                        booking.EventID = viewModel.SelectedEventID;
                        booking.EventTypeID = viewModel.SelectedEventTypeID;
                        booking.StartDate = viewModel.StartDate;
                        booking.EndDate = viewModel.EndDate;

                        _context.Update(booking);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BookingExists(viewModel.BookingID)) return NotFound();
                        else throw;
                    }
                }
            }

            viewModel.Venues = GetVenuesList();
            viewModel.Events = GetEventsList();
            viewModel.EventTypes = GetEventTypesList();
            return View(viewModel);
        }

        private bool BookingExists(int id) => _context.Bookings.Any(e => e.BookingID == id);

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var booking = await _context.Bookings
                .Include(b => b.Venue)
                .Include(b => b.Event)
                .Include(b => b.EventType)
                .FirstOrDefaultAsync(m => m.BookingID == id);

            if (booking == null) return NotFound();
            return View(booking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var booking = await _context.Bookings
                .Include(b => b.Venue)
                .Include(b => b.Event)
                .FirstOrDefaultAsync(m => m.BookingID == id);

            if (booking == null) return NotFound();
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> GetVenuesList() => _context.Venues.Select(v => new SelectListItem { Value = v.VenueID.ToString(), Text = v.VenueName }).ToList();
        private IEnumerable<SelectListItem> GetEventsList() => _context.Events.Select(e => new SelectListItem { Value = e.EventID.ToString(), Text = e.EventName }).ToList();
        private IEnumerable<SelectListItem> GetEventTypesList() => _context.EventTypes.Select(et => new SelectListItem { Value = et.EventTypeID.ToString(), Text = et.Name }).ToList();
    }
}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Gemini, 2026