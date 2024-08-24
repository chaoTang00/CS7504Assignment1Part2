using A1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class StaffController : Controller
    {
        private readonly A1DbContext _context;

        public StaffController(A1DbContext context)
        {
            _context = context;
        }

        //[Authorize]
        public IActionResult BookingList()
        {
            var bookingList = _context.CustomerBookings.ToList();
            return View(bookingList);
        }


        // Login function

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Staff staff)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(s => s.StaffId == staff.StaffId && s.Password == staff.Password);
            if (staffInDb == null) 
            {
                ViewBag.Message = "Invalid login";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Booking");
            }
        }



        // Register function
        [HttpGet]
        public IActionResult Register()
        {
            if (TempData["SecurityQuestionPassed"] == null || !(bool)TempData["SecurityQuestionPassed"])
            {
                return RedirectToAction("SecurityQuestion");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staffs.Add(staff);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(staff);
        }

        // Security Question function
        [HttpGet]
        public IActionResult SecurityQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SecurityQuestion(string answer)
        {
            if (answer.ToLower() == "chao tang") // The correct answer
            {
                TempData["SecurityQuestionPassed"] = true;
                return RedirectToAction("Register");
            }
            else
            {
                ViewBag.Message = "You are not a staff!";
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
