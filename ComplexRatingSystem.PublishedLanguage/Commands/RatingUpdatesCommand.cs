using MediatR;

namespace ComplexRatingSystem.PublishedLanguage.Commands
{
    public class RatingUpdatesCommand : IRequest
    {
        public int UserId { get; set; }
        public int ExternalId { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
    }
}
