using Application.Attendants.Queries.Common;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace Application.Inscriptions.Commands.CreateInscription
{
    public class CreateInscriptionCommand : IRequest
    {
        public int PresentationId { get; set; }

        public string Email { get; set; }
    }
}
