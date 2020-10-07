using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Presentations.Commands.UpdatePresentation
{
    public class UpdatePresentationCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime? Schedule { get; set; }

        public int? SpeakerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
