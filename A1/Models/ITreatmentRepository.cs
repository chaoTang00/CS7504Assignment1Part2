namespace A1.Models
{
    public interface ITreatmentRepository
    {
        IEnumerable<Treatment> AllTreatments { get; }
        IEnumerable<Treatment> OnPromotion { get; }
        Treatment? GetTreatmentById(int treatmentId);
        IEnumerable<Treatment> SearchTreatments(string searchQuery);
    }
}
