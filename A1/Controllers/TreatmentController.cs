using A1.Models;
using A1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public IActionResult List()
        {
            // return View(_treatmentRepository.AllTreatments);

            TreatmentListViewModel treatmentListViewModel = new TreatmentListViewModel(_treatmentRepository.AllTreatments, "Our Services");
            return View(treatmentListViewModel);
        }

        public IActionResult Details(int id)
        {
            var treatment = _treatmentRepository.GetTreatmentById(id);
            if (treatment == null)
            {
                return NotFound();
            }
            return View(treatment);
        }
    }
}
