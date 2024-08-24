
namespace A1.Models
{
    public class MockTreatmentRepository : ITreatmentRepository
    {
        public IEnumerable<Treatment> AllTreatments =>
            new List<Treatment>
            {
                new Treatment {TreatmentId = 1, TreatmentName = "Emergency Dentist", Description = "Dental emergencies can include toothache, dental injuries like missing teeth, because they've been knocked our during sport. Other dental emergencies can include fractured teeth, facial swelling, or lost fillings.", ImageThumbnailUrl = "images/emergency.jpg", IsOnPromotion = false, Price = 79.99M},
                new Treatment {TreatmentId = 2, TreatmentName = "Teeth Whitening", Description = "Teeth whitening or bleaching has become more popular in recent years. Whitening your teeth is a great way to help restore self-esteem. When your teeth literally shine, it can help you feel more confident.", ImageThumbnailUrl = "images/dental-hygiene.jpg", IsOnPromotion = true, Price = 149.99M},
                new Treatment {TreatmentId = 3, TreatmentName = "Exam & X-Rays Check-Up", Description = "When you book with us for a routine exam and x-rays check-up your teeth and mouth will thank you. Well, they would if they could talk.", ImageThumbnailUrl = "images/x-rays.jpg", IsOnPromotion = false, Price = 39.99M},
                new Treatment {TreatmentId = 4, TreatmentName = "Wisdom Teeth Removal", Description = "Getting your wisdom teeth removed is a fairly common procedure. You might feel nervous about it, but you can relax. It’s not as bad as you might think.", ImageThumbnailUrl = "images/wisdom-teeth.jpg", IsOnPromotion = true, Price = 199.99M}
            };

        public IEnumerable<Treatment> OnPromotion
        {
            get
            {
                return AllTreatments.Where(t => t.IsOnPromotion);
            }
        }

        public Treatment? GetTreatmentById(int treatmentId) => AllTreatments.FirstOrDefault(t => t.TreatmentId == treatmentId);
      
        IEnumerable<Treatment> ITreatmentRepository.SearchTreatments(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
