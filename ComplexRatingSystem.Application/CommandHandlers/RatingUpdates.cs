using ComplexRatingSystem.Data;
using ComplexRatingSystem.Models;
using MediatR;

using RatingSystem.PublishedLanguage.Commands;
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

        public Task<Unit> Handle(RatingUpdatesCommand request, CancellationToken cancellationToken)
        {
            
            return Unit.Task;
        }
    }
}


