using Application.Attendants.Queries.Common;
using Application.Speakers.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Attendants.Queries.GetAttendantDetails
{
    public class GetAttendantDetailsQuery : IRequest<AttendantVm>
    {
        public int Id { get; set; }
    }
}
