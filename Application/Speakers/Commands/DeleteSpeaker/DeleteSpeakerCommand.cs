using MediatR;
using System.Text;

namespace Application.Speakers.Commands.DeleteSpeaker
{
    public class DeleteSpeakerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
