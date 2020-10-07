using Application.Attendants.Queries.Common;
using MediatR;

namespace Application.Inscriptions.Queries.GetAllAttendants
{
    public class GetAllAttendantsQuery : IRequest<AttendantsListVm>
    {
        public int Id { get; set; }
    }
}
