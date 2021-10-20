using Microsoft.AspNetCore.Mvc;
using RatingSystem.Application.Queries;
using RatingSystem.PublishedLanguage.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;

        public RatingController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<string> Rating(RatingUpdatesCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return "OK";
        }

        //[HttpGet]
        //[Route("ListOfAccounts")]
        //// query: http://localhost:5000/api/Account/ListOfAccounts?PersonId=1&Cnp=1961231..
        //// route: http://localhost:5000/api/Account/ListOfAccounts/1/1961231..
        //public async Task<List<ListOfAccounts.Model>> GetListOfAccounts([FromQuery] ListOfAccounts.Query query, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(query, cancellationToken);
        //    return result;
        //}
    }
}
