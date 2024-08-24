using A1.Models;
using A1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace A1.Controllers
{
    public class HomeController : Controller
    {
       private readonly ITreatmentRepository _treatmentRepository;

        public HomeController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public IActionResult Index()
        {
            var onPromotion = _treatmentRepository.OnPromotion;
            var homeViewModel = new HomeViewModel(onPromotion);
            return View(homeViewModel);
        }


        // Search function
        public IActionResult Search(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                ModelState.AddModelError("query", "Please enter a search term.");
                return View("Index");
            }

            var searchResults = _treatmentRepository.SearchTreatments(searchQuery)
                .ToList();

            return View("SearchResults", searchResults);
        }
    }
}
