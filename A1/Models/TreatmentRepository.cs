using Microsoft.EntityFrameworkCore;

namespace A1.Models
{
    public class TreatmentRepository:ITreatmentRepository
    {
        private readonly A1DbContext _a1DbContext;

        public TreatmentRepository(A1DbContext a1DbContext)
        {
            _a1DbContext = a1DbContext;
        }

        IEnumerable<Treatment> ITreatmentRepository.AllTreatments
        {
            get 
            {
                return _a1DbContext.Treatments;
            }
        }

        IEnumerable<Treatment> ITreatmentRepository.OnPromotion
        {
            get
            {
                return _a1DbContext.Treatments.Where(t => t.IsOnPromotion);
            }
        }

        Treatment? ITreatmentRepository.GetTreatmentById(int treatmentId)
        {
            return _a1DbContext.Treatments.FirstOrDefault(t => t.TreatmentId == treatmentId);
        }

        IEnumerable<Treatment> ITreatmentRepository.SearchTreatments(string searchQuery)
        {
            //throw new NotImplementedException();

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                // If the search query is empty or whitespace, return all treatments
                return _a1DbContext.Treatments;
            }
            else
            {
                // Search treatments by name or any other relevant words
                return _a1DbContext.Treatments
                    .Where(t => t.TreatmentName.Contains(searchQuery) || t.Description.Contains(searchQuery));
            }
        }
    }
}
