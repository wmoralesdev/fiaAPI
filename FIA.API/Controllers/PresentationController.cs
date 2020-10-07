using System.Threading.Tasks;
using Application.Presentations.Commands.CreatePresentation;
using Application.Presentations.Commands.DeletePresentation;
using Application.Presentations.Commands.UpdatePresentation;
using Application.Presentations.Queries.Common;
using Application.Presentations.Queries.GetAllPresentations;
using Application.Presentations.Queries.GetPresentationDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentationController : ApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PresentationVm>> GetCurrent(int id)
        {
            var query = new GetPresentationDetailsQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PresentationListVm>> GetAll()
        {
            var query = new GetAllPresentationsQuery();

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreatePresentation(CreatePresentationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdatePresentation(UpdatePresentationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeletePresentation(int id)
        {
            var command = new DeletePresentationCommand
            {
                Id = id
            };

            return Ok(await Mediator.Send(command));
        }
    }
}
