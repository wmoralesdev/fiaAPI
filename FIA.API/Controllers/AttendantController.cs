using System.Threading.Tasks;
using Application.Attendants.Commands.CreateAttendant;
using Application.Attendants.Commands.DeleteAttendant;
using Application.Attendants.Commands.UpdateAttendant;
using Application.Attendants.Queries.Common;
using Application.Attendants.Queries.GetAllAttendants;
using Application.Attendants.Queries.GetAttendantDetails;
using Application.Speakers.Queries.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendantController : ApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AttendantVm>> GetCurrent(int id)
        {
            var query = new GetAttendantDetailsQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AttendantsListVm>> GetAll()
        {
            var query = new GetAllAttendantsQuery();

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateAttendant(CreateAttendantCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateAttendant(UpdateAttendantCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteAttendant(int id)
        {
            var command = new DeleteAttendantCommand
            {
                Id = id
            };

            return Ok(await Mediator.Send(command));
        }
    }
}
