using A1.Models;

namespace A1.ViewModels
{
    public class TreatmentListViewModel
    {
        public IEnumerable<Treatment> Treatments { get; }
        public string? CurrentPromotion { get; }

        public TreatmentListViewModel(IEnumerable<Treatment> treatments, string? currentPromotion)
        {
            Treatments = treatments;
            CurrentPromotion = currentPromotion;
        }
    }
}
