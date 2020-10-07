using Domain.BaseIdentities;
using Domain.Presentations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Speakers.Commands
{
    public class CreateSpeakerCommand : IRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
