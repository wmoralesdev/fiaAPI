using Domain.Presentations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Attendants.Commands.UpdateAttendant
{
    public class UpdateAttendantCommand : IRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
