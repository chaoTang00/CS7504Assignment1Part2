using A1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    public class BookingController : Controller
    {
        private readonly A1DbContext _context;

        public BookingController(A1DbContext context)
        {
            _context = context;
        }

        public IActionResult BookingForm()
        {
            var treatmentNames = _context.Treatments.Select(t => t.TreatmentName).ToList();
            ViewBag.TreatmentNames = treatmentNames;
            return View();
        }

        // POST: Booking created with validation
        [HttpPost]
        public IActionResult Book(CustomerBooking booking)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the selected service from the dropdown
                string selectedService = Request.Form["ServicesRequired"];

                // Assign the selected service to the booking object
                booking.ServicesRequired = selectedService;

                _context.CustomerBookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("BookingSuccess");
            }
            return View("BookingForm", booking);
        }

        public IActionResult BookingSuccess()
        {
            return View();
        }


        // Edit Action - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _context.CustomerBookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // Edit Action - POST
        [HttpPost]
        public IActionResult Edit(CustomerBooking booking)
        {
            if (ModelState.IsValid)
            {
                _context.CustomerBookings.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        [HttpPost]
        public IActionResult Update(CustomerBooking booking)
        {
            if (ModelState.IsValid)
            {
                _context.CustomerBookings.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", booking);
        }

        // Delete Action - GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var booking = _context.CustomerBookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // Delete Action - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.CustomerBookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.CustomerBookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var bookingList = await _context.CustomerBookings.ToListAsync();
            return View(bookingList);
        }
    }
}
