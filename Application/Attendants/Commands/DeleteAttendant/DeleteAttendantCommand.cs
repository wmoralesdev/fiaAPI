using MediatR;
using System.Text;

namespace Application.Attendants.Commands.DeleteAttendant
{
    public class DeleteAttendantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
