using Domain.BaseIdentities;
using Domain.Presentations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Speakers
{
    public class Speaker : BaseIdentity
    {
        public virtual Presentation Presentation { get; set; }

        public Speaker(string fullName, string email, string phoneNumber, IdentityRole role)
            : base(fullName, email, phoneNumber, role)
        {
        }
    }
}
