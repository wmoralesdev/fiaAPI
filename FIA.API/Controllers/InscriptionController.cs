using Application.Attendants.Queries.Common;
using Application.Inscriptions.Commands.CreateInscription;
using Application.Inscriptions.Queries.GetAllAttendants;
using Application.Inscriptions.Queries.GetAllPresentations;
using Application.Presentations.Queries.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FIA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InscriptionController : ApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AttendantsListVm>> GetAllAttendants(int id)
        {
            var query = new GetAllAttendantsQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("attendant/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PresentationListVm>> GetAllPresentations(int id)
        {
            var query = new GetAllPresentationsQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateInscription(CreateInscriptionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
