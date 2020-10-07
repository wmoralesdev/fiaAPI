using Application.Common.Mappings;
using AutoMapper;
using Domain.Speakers;

namespace Application.Speakers.Queries.Common
{
    public class SpeakerVm : IMapFrom<Speaker>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Speaker, SpeakerVm>();
        }
    }
}
