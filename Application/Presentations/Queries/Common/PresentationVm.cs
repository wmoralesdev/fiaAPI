using Application.Attendants.Queries.Common;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Presentations;
using Domain.Speakers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Presentations.Queries.Common
{
    public class PresentationVm : IMapFrom<Presentation>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Presentation, PresentationVm>();
        }

        public int PresentationId { get; set; }

        public DateTime Schedule { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
