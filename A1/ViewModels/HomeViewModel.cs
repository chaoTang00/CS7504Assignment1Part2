using A1.Models;

namespace A1.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Treatment> OnPromotion { get; }

        public HomeViewModel(IEnumerable<Treatment> onPromotion)
        {
            OnPromotion = onPromotion;
        }
    }
}
