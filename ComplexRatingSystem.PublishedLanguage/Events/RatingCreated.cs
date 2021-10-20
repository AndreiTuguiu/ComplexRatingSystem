using MediatR;

namespace ComplexRatingSystem.PublishedLanguage.Events
{
    public class RatingCreated: INotification
    {
        public int UserId { get; set; }
        public int ExternalId { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
    }
}
