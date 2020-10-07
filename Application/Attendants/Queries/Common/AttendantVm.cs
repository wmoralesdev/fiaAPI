using Application.Common.Mappings;
using AutoMapper;
using Domain.Attendants;
using Domain.Speakers;

namespace Application.Attendants.Queries.Common
{
    public class AttendantVm : IMapFrom<Attendant>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attendant, AttendantVm>();
        }
    }
}
