using System.Threading.Tasks;
using Application.Speakers.Commands;
using Application.Speakers.Commands.DeleteSpeaker;
using Application.Speakers.Queries.Common;
using Application.Speakers.Queries.GetAllSpeakers;
using Application.Speakers.Queries.GetSpeakerDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeakerController : ApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SpeakerVm>> GetCurrent(int id)
        {
            var query = new GetSepakerDetailsQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SpeakerListVm>> GetAll()
        {
            var query = new GetAllSpeakersQuery();

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateSpeaker(CreateSpeakerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateSpeaker(UpdateSpeakerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteSpeaker(int id)
        {
            var command = new DeleteSpeakerCommand
            {
                Id = id
            };

            return Ok(await Mediator.Send(command));
        }
    }
}
