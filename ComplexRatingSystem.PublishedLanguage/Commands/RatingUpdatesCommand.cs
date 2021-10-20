using MediatR;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class RatingUpdatesCommand : IRequest
    {
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public int Category { get; set; }
        public decimal Rating { get; set; }
    }
}
