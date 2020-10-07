using Application.Attendants.Queries.Common;
using Application.Speakers.Queries.Common;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace Application.Attendants.Queries.GetAllAttendants
{
    public class GetAllAttendantsQuery : IRequest<AttendantsListVm>
    {
    }
}
