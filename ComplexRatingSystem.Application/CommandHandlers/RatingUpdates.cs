using ComplexRatingSystem.Data;
using ComplexRatingSystem.Models;
using ComplexRatingSystem.PublishedLanguage.Commands;
using ComplexRatingSystem.PublishedLanguage.Events;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.WriteOperations
{
    public class RatingUpdates : IRequestHandler<RatingUpdatesCommand>
    {
        private readonly IMediator _mediator;
        private readonly ConferenceDbContext _dbContext;

        public RatingUpdates(IMediator mediator, ConferenceDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RatingUpdatesCommand request, CancellationToken cancellationToken)
        {
            var rating = _dbContext.ConferenceXattendeeRatings.FirstOrDefault(x => x.ExternalId == request.ExternalId && x.Category == request.Category && x.UserId == request.UserId);

            if (rating == null)
            {
                rating = new ConferenceXattendeeRating()
                {
                    ExternalId = request.ExternalId,
                    Category=request.Category,
                    UserId=request.UserId,
                    Rating=request.Rating
                };
                _dbContext.ConferenceXattendeeRatings.Add(rating);

                RatingCreated ratingCreated = new()
                {
                    ExternalId=request.ExternalId,
                    Category=request.Category,
                    UserId=request.UserId,
                    Rating=request.Rating
                };
                await _mediator.Publish(ratingCreated, cancellationToken);
            }
            else
            {
                rating.Rating = request.Rating;
                RatingUpdated ratingUpdated = new()
                {
                    Rating = request.Rating
                };
                await _mediator.Publish(ratingUpdated, cancellationToken);
            }

            _dbContext.SaveChanges();

            var ratingAVG = _dbContext.ConferenceRatings.FirstOrDefault(x => x.ExternalId == request.ExternalId);
            if (ratingAVG == null)
            {
                ratingAVG = new ConferenceRating()
                {
                    ExternalId = request.ExternalId,
                    Avgrating = request.Rating
                };
                _dbContext.ConferenceRatings.Add(ratingAVG);
            }
            else
            {
                var avg = _dbContext.ConferenceXattendeeRatings.Where(x => x.ExternalId == request.ExternalId).Average(x=> x.Rating);
                ratingAVG.Avgrating = avg;
            }
            _dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}


