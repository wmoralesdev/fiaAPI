using MediatR;
using System;

namespace Application.Presentations.Commands.CreatePresentation
{
    public class CreatePresentationCommand : IRequest
    {
        public DateTime Schedule { get; set; }

        public int? SpeakerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
