using MediatR;

namespace Application.Presentations.Commands.DeletePresentation
{
    public class DeletePresentationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
