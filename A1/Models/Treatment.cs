namespace A1.Models
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public string TreatmentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
